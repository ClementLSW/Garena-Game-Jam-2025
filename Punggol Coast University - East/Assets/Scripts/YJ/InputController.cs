using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Gamepad player1, player2;

    [SerializeField] InputAction joinAction;
    [SerializeField] GameObject playerPrefab;

    GameObject player1Obj = null, player2Obj = null;

    private void Update()
    {
        if (player1 == null && Gamepad.all[0] != null)
        {
            player1 = Gamepad.all[0];
        }

        if (player2 == null && Gamepad.all[1] != null)
        {
            player2 = Gamepad.all[1];
        }

        Debug.Log($"Player 1 {player1.name} | Player 2 {player2}");
        Debug.Log($"1LT {player1.leftTrigger.isPressed} 1RT {player1.rightTrigger.isPressed} | 2LT {player2.leftTrigger.isPressed} 2RT {player2.rightTrigger.isPressed}");
        if (player1.leftTrigger.isPressed && player1.rightTrigger.isPressed && player1Obj == null)
        {
            player1Obj = Instantiate(playerPrefab);
            FindAnyObjectByType<ConnectionTest>().JoinPlayer();
        }

        if (player2.leftTrigger.isPressed && player2.rightTrigger.isPressed && player2Obj == null)
        {
            player2Obj = Instantiate(playerPrefab);
            FindAnyObjectByType<ConnectionTest>().JoinPlayer();
        }
    }
}
