using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    static List<Player> players = new();
    static ResumeScroll scrollController;
    int playerId;
    Vector2 currentInputValue, targetInputValue;

    float power = 0f;

    private void Start()
    {
        playerId = players.Count;
        players.Add(this);
        scrollController = scrollController != null ? scrollController : FindAnyObjectByType<ResumeScroll>();
    }
    private void Update()
    {
        //currentInputValue = Vector2.Lerp(currentInputValue, targetInputValue, Time.deltaTime);
        scrollController.SubmitInput(playerId, currentInputValue * (power + 1));
        Debug.Log($"Power {power}");
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
