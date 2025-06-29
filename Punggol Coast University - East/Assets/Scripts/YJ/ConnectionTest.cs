using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConnectionTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1, player2, startGame;
    int connectedPlayers = 0;

    public void JoinPlayer(PlayerInput playerInput)
    {
        connectedPlayers++;
        player1.text = connectedPlayers > 0 ? "Player 1\nConnected" : "Player 1\nNot connected";
        player2.text = connectedPlayers > 1 ? "Player 2\nConnected" : "Player 2\nNot connected";
        startGame.gameObject.SetActive(connectedPlayers > 1);
    }

    public void LeftPlayer(PlayerInput playerInput)
    {
        connectedPlayers--;
        player1.text = connectedPlayers > 0 ? "Player 1\nConnected" : "Player 1\nNot connected";
        player2.text = connectedPlayers > 1 ? "Player 2\nConnected" : "Player 2\nNot connected";
        startGame.gameObject.SetActive(connectedPlayers > 1);
    }

    public void StartGame()
    {
        if (connectedPlayers > 1) GameManager.Instance.SwapState(GameManager.State.Ready);
        foreach (var player in Player.players)
        {
            player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Resume Scrolling");
            Debug.Log(player.GetComponent<PlayerInput>().currentActionMap);
        }
    }
}
