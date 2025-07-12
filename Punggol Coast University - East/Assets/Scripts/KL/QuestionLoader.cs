using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class QuestionLoader : MonoBehaviour
{
    public static Queue<QuestionInstance> QuestionQueue;
    public TMP_Text questionText;
    public bool initialQuestion = true;

    public GameObject Wheel;
    public Vector3 wheel1Pos = new Vector3(-4, 0, 0);
    public Vector3 wheel2Pos = new Vector3(4, 0, 0);

    public List<GameObject> answerBoxes1 = new List<GameObject>();
    public List<GameObject> answerBoxes2 = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameObject wheel1 = Instantiate(Wheel, wheel1Pos, Quaternion.identity);
        //foreach (Transform child in wheel1.transform)
        //{
        //    if (child.CompareTag("AnswerBox"))
        //    {
        //        answerBoxes1.Add(child.gameObject);
        //    }
        //}

        //GameObject wheel2 = Instantiate(Wheel, wheel2Pos, Quaternion.identity);
        //foreach (Transform child in wheel2.transform)
        //{
        //    if (child.CompareTag("AnswerBox"))
        //    {
        //        answerBoxes2.Add(child.gameObject);
        //    }
        //}

        //QuestionQueue = QuestionInstance.Instance.GenerateAllQuestions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetQuestion()
    {
        if (initialQuestion == false)
        {
            QuestionQueue.Dequeue();
        }
        else
        {
            initialQuestion = false;

            var currentQuestion = QuestionQueue.Peek();
            questionText.text = currentQuestion.Prompt;


            List<string> allAnswers = currentQuestion.Answers;
            string correctAnswer = currentQuestion.CorrectAnswer;
            allAnswers.Add(correctAnswer);


            for (int i = 0; i < allAnswers.Count; i++)
            {
                if (i < allAnswers.Count)
                {
                    answerBoxes1[i].GetComponentInChildren<TMP_Text>().text = allAnswers[i];
                    answerBoxes2[i].GetComponentInChildren<TMP_Text>().text = allAnswers[i];

                    /*if (i == 5) // last is correct answer
                    {
                        answerBoxes1[i].GetComponent<AnswerBoxControl>().isAnswer = true;
                        answerBoxes2[i].GetComponent<AnswerBoxControl>().isAnswer = true;
                    }*/
                }
            }
        }
    }
}
