using Assets.Scripts.Resume;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Resume.ResumeUtils;
using static ResumeGenerator;

public class QuestionInstance
{
    public string Prompt;
    public string CorrectAnswer;
    public List<string> Answers;

    public ResumeData data;

    public Queue<QuestionInstance> GenerateAllQuestions()
    {
        var questionQueue = new Queue<QuestionInstance>();

        foreach (Category category in Enum.GetValues(typeof(Category)))
        {
            var question = new QuestionInstance();
            question = CreateFromCategory(category);
            questionQueue.Enqueue(question);
        }

        return questionQueue;
    }


    public QuestionInstance CreateFromCategory(Category category)
    {
        data = Instance.GetResumeData;
        QuestionInstance question = new QuestionInstance();
        question.Prompt = GetPromptForCategory(Instance, category);
        question.CorrectAnswer = GetAnswerForCategory(data, category);
        question.Answers = new List<string>(Instance.CategoryDataMap[category].PossibleAnswers);
        
        // Do not touch this, held together by math, hopes and prayers
        question.Answers.AddRange(Instance.CategoryDataMap[
            (Category)
            ((int)category + Random.Range(1, 6) % 6)
            ].PossibleAnswers);
        
        return question;
    }
}
