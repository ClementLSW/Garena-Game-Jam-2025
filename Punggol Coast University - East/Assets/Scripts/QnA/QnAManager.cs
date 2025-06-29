using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class QnAManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Wheel1Options;
    [SerializeField] private List<GameObject> Wheel2Options;
    [SerializeField] private GameObject QuestionField;

    private QuestionInstance question;


    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        if (_gameManager == null)
        {
            Debug.LogError("GameManager instance not found!");
            return;
        }
    }

    /// <summary>
    /// dequeue a question from the current question set and populate the UI elements with the question and answers.
    /// </summary>
    public void Populate()
    {
        question = _gameManager.CurrentQuestionSet.Dequeue();
        QuestionField.GetComponentInChildren<TMP_Text>().text = question.Prompt;

        for (int i = 0; i < 6; i++)
        {
            Wheel1Options[i].GetComponentInChildren<TextMeshProUGUI>().text = question.Answers[i];
            Wheel2Options[i].GetComponentInChildren<TextMeshProUGUI>().text = question.Answers[i];
        }
    }

    /// <summary>
    /// Call this to compare answer
    /// </summary>
    /// <param name="selectedanswer"></param>
    /// <returns>Boolean stating match or no match</returns>
    public bool ValidateAnswer(string selectedanswer)
    {
        return selectedanswer == question.CorrectAnswer;
    }
}
