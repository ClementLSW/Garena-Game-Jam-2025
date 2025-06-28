using UnityEngine;
using System.Collections;
using UnityEditor;
using TMPro;

public class AnswerBoxControl : MonoBehaviour
{
    public bool boxInFocus = false;
    public bool isAnswer = false;

    public int boxPosition;

    public TMP_Text answerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        answerText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L)) // add input here
        {
            if (boxInFocus == true && isAnswer)
            {
                // win logic here
            }
            else
            {
                // lose logic here
            }
        }
    }
}
