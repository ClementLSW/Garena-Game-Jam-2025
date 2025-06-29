using TMPro;
using UnityEngine;

public class Sidekick : MonoBehaviour
{
    [SerializeField] Sprite normal, failure, success, talking;
    GameObject canvas;

    [SerializeField] TextMeshProUGUI question;

    private void Start()
    {
        question.text = QuestionInstance.Instance.Prompt;
    }
}
