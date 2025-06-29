using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static List<Player> players = new();
    static ResumeScroll scrollController;
    int playerId;
    Vector2 currentInputValue, targetInputValue;

    float power = 0f;

    [SerializeField] AnimatorController controllerLeft, controllerRight;
    Wheel playersWheel;

    private void Start()
    {
        playerId = players.Count;
        players.Add(this);
        GetComponent<Animator>().runtimeAnimatorController = playerId % 2 != 0 ? controllerLeft : controllerRight;
        playersWheel = FindObjectsByType<Wheel>(sortMode: FindObjectsSortMode.None).Where(x => x.WheelId == playerId).FirstOrDefault();
    }

    static public void FindScrollController()
    {
        scrollController = scrollController ?? FindAnyObjectByType<ResumeScroll>();
    }
    private void Update()
    {
        //currentInputValue = Vector2.Lerp(currentInputValue, targetInputValue, Time.deltaTime);
        if (scrollController == null) return;
        scrollController.SubmitInput(playerId, currentInputValue * (power + 1));
        //Debug.Log($"Power {power}");
        DepletePower();

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
