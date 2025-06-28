using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static ResumeGenerator;

public class QuestionInstance : MonoBehaviour
{
    public List<string> Prompts;
    public string CorrectAnswer;
    public List<string> PossibleAnswers;

    public ResumeData data;

    public QuestionInstance GenerateQuestion(string category, string decoycategory)
    {
        data = Instance.GetResumeData;
    }

    private string GetValueByField(ResumeData data, string field)
    {
        return field switch
        {
            "FavoriteFood" => data.FavoriteFood,
            "Hobby" => data.Hobby,
            "Pet" => data.Pet,
            "Hometown" => data.Hometown,
            "Weakness" => data.Weakness,
            _ => ""
        };
    }
}
