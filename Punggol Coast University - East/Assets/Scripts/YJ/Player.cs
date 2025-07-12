using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static List<Player> players = new();
    static ResumeScroll scrollController;
    public int playerId;
    Vector2 currentInputValue, targetInputValue;

    float power = 0f;

    [SerializeField] RuntimeAnimatorController controllerLeft, controllerRight;
    Wheel playersWheel;

    private void Start()
    {
        playerId = players.Count;
        players.Add(this);
        GetComponent<Animator>().runtimeAnimatorController = playerId % 2 != 0 ? controllerLeft : controllerRight;
    }

    static public void FindScrollController()
    {
        scrollController = scrollController != null ? scrollController : FindAnyObjectByType<ResumeScroll>();
    }

    public void FindPlayersWheel()
    {
        playersWheel = FindObjectsByType<Wheel>(sortMode: FindObjectsSortMode.None).Where(x => x.WheelId == playerId).FirstOrDefault();
    }
    private void Update()
    {
        //Read Inputs
        switch (GameManager.Instance.currentState)
        {
            case GameManager.State.NotReady:
                switch (playerId)
                {
                    case 0:
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            if (FindAnyObjectByType<ConnectionTest>().connectedPlayers > 1) {FindAnyObjectByType<ConnectionTest>().StartGame(); return; }
                            FindAnyObjectByType<ConnectionTest>().JoinPlayer();
                            GetComponent<SpriteRenderer>().enabled = true;
                        }
                        break;
                    case 1:
                        if (Input.GetKeyDown(KeyCode.Return))
                        {
                            if (FindAnyObjectByType<ConnectionTest>().connectedPlayers > 1) {FindAnyObjectByType<ConnectionTest>().StartGame(); return; }
                            FindAnyObjectByType<ConnectionTest>().JoinPlayer();
                            GetComponent<SpriteRenderer>().enabled = true;
                        }
                        break;
                }
                break;
            case GameManager.State.Ready:
                break;
            case GameManager.State.Resume:
                Debug.Log("Test Resume state");
                if (scrollController == null) return;
                switch (playerId)
                {
                    case 0:
                        if (Input.GetKeyDown(KeyCode.Space)) power += 1.0f;
                        break;
                    case 1:
                        if (Input.GetKeyDown(KeyCode.Return)) power += 1.0f;

                        break;
                }
                var horizontal = 0f;
                var vertical = 0f;
                switch (playerId)
                {
                    case 0:
                        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                        {
                            horizontal = 0f;
                        }
                        else if (Input.GetKey(KeyCode.A))
                        {
                            horizontal = -1f;
                        }
                        else if (Input.GetKey(KeyCode.D))
                        {
                            horizontal = 1f;
                        }
                        else
                        {
                            horizontal = 0f;
                        }

                        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
                        {
                            vertical = 0f;
                        }
                        else if (Input.GetKey(KeyCode.S))
                        {
                            vertical = -1f;
                        }
                        else if (Input.GetKey(KeyCode.W))
                        {
                            vertical = 1f;
                        }
                        else
                        {
                            vertical = 0f;
                        }

                        currentInputValue = new Vector2(horizontal, vertical);
                        break;
                    case 1:
                        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                        {
                            horizontal = 0f;
                        }
                        else if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            horizontal = -1f;
                        }
                        else if (Input.GetKey(KeyCode.RightArrow))
                        {
                            horizontal = 1f;
                        }
                        else
                        {
                            horizontal = 0f;
                        }

                        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
                        {
                            vertical = 0f;
                        }
                        else if (Input.GetKey(KeyCode.DownArrow))
                        {
                            vertical = -1f;
                        }
                        else if (Input.GetKey(KeyCode.UpArrow))
                        {
                            vertical = 1f;
                        }
                        else
                        {
                            vertical = 0f;
                        }
                        currentInputValue = new Vector2(horizontal, vertical);
                        break;
                }
                //Debug.Log($"{gameObject.name} input: {currentInputValue}");
                scrollController.SubmitInput(playerId, currentInputValue * (power + 1));
                DepletePower();
                break;
            case GameManager.State.Date:
                switch (playerId)
                {
                    case 0:
                        if (Input.GetKeyDown(KeyCode.S)) playersWheel.MoveNext();
                        if (Input.GetKeyDown(KeyCode.W)) playersWheel.MovePrev();
                        if (Input.GetKeyDown(KeyCode.Space)) playersWheel.SubmitAnswer();
                        break;
                    case 1:
                        if (Input.GetKeyDown(KeyCode.DownArrow)) playersWheel.MoveNext();
                        if (Input.GetKeyDown(KeyCode.UpArrow)) playersWheel.MovePrev();
                        if (Input.GetKeyDown(KeyCode.Return)) playersWheel.SubmitAnswer();
                        break;
                }
                break;
        }


        //currentInputValue = Vector2.Lerp(currentInputValue, targetInputValue, Time.deltaTime);
        //Debug.Log($"Power {power}");

    }
    public void PerformResumeScroll(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<Vector2>());
        currentInputValue = ctx.ReadValue<Vector2>();
        //if (ctx.canceled) targetInputValue = Vector2.zero;
    }

    public void PerformPowerSpam(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) power += 1.0f;

    }

    public void PerformChooseNextAnswer(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) playersWheel.MoveNext();
    }

    public void PerformChoosePrevAnswer(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) playersWheel.MovePrev();
    }

    public void PerformStartGame(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) FindAnyObjectByType<ConnectionTest>().StartGame();
    }

    void DepletePower()
    {
        power -= Time.deltaTime;
        power = Mathf.Clamp(power, 0, 1);
    }

    private void OnDestroy()
    {
        players.Clear();
    }
}
