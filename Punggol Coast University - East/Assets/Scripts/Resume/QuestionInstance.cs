using Assets.Scripts.Resume;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Resume.ResumeUtils;
using static ResumeGenerator;

public class QuestionInstance
{

    private static QuestionInstance _instance;
    private ResumeDataDeserializer deserializer;

    public static QuestionInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new QuestionInstance();
            }
            return _instance;
        }
    }
    public string Prompt;
    public string CorrectAnswer;
    public List<string> Answers;

    public ResumeData data;

    // Call this when entering the question scene
    public Queue<QuestionInstance> GenerateAllQuestions()
    {
        List<QuestionInstance> questionList = new List<QuestionInstance>();

        foreach (Category category in Enum.GetValues(typeof(Category)))
        {
            QuestionInstance question = CreateFromCategory(category);
            questionList.Add(question);
        }

        // Fisher-Yates shuffle
        int n = questionList.Count;
        System.Random rng = new System.Random();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (questionList[n], questionList[k]) = (questionList[k], questionList[n]);
        }


        return new Queue<QuestionInstance>(questionList);
    }


    public QuestionInstance CreateFromCategory(Category category)
    {
        data = ResumeGenerator.Instance.GetResumeData;
        QuestionInstance question = new QuestionInstance();
        question.Prompt = GetPromptForCategory(ResumeGenerator.Instance, category);
        question.CorrectAnswer = GetAnswerForCategory(data, category);
        question.Answers = new List<string>(ResumeGenerator.Instance.CategoryDataMap[category].PossibleAnswers);
        
        // Do not touch this, held together by math, hopes and prayers
        question.Answers.AddRange(ResumeGenerator.Instance.CategoryDataMap[
            (Category)
            ((int)category + UnityEngine.Random.Range(1, 6) % 6)
            ].PossibleAnswers);
        
        return question;
    }
}
