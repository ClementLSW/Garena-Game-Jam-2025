using TMPro;
using UnityEngine;

public class AnswerBoxControl : MonoBehaviour
{
    public bool boxInFocus = false;
    public bool isAnswered = false;

    public int boxPosition;

    [SerializeField] Sprite normalBox, coloredBox;

    public TMP_Text answerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        answerText = GetComponentInChildren<TMP_Text>();
    }

    public void AnswerLocked(bool isCorrectAnswer)
    {
        isAnswered = true;
        GetComponent<SpriteRenderer>().sprite = coloredBox;
        GetComponent<SpriteRenderer>().color = isCorrectAnswer ? Color.green : Color.red;

    }
    public void AnswerUnlock()
    {
        isAnswered = false;
        GetComponent<SpriteRenderer>().sprite = normalBox;
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
