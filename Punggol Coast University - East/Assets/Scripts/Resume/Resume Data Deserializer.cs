using Assets.Scripts.Resume;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ResumeDataDeserializer : MonoBehaviour
{


    public List<string> names;
    public List<Sprite> sprites;
    public string GetHeroName()
    {
        return "John Doe";
    }

    public string GetGovtName()
    {
        return "Johnathan Doe";
    }

    public Sprite GetSprite()
    {
        return null; // Placeholder for sprite retrieval logic
    }

    public int GetAge()
    {
        return Random.Range(18,81);
    }

    public int GetDebutYear()
    {
        return Random.Range(2007, 2026);
    }

    public int GetCrimeStopped()
    {
        return Random.Range(0, 10000);
    }

    public int GetPowersUsed()
    {
        return Random.Range(0, 100);
    }

    public string GetHeight()
    {
        int feet = Random.Range(5, 7);
        int inches = Random.Range(0, 12);

        return $"{feet} feet {inches} inches"; // Placeholder for height retrieval logic
    }

    public string GetWeight()
    {
        int pounds = Random.Range(100, 300);
        return $"{pounds} lbs"; // Placeholder for weight retrieval logic
    }

    public string GetPower()
    {
        return ResumeGenerator.Instance
            .CategoryDataMap[Category.Superpower]
            .PossibleAnswers[Random.Range(0, 3)];
    }
    public string GetWeakness()
    {
        return ResumeGenerator.Instance
            .CategoryDataMap[Category.Weakness]
            .PossibleAnswers[Random.Range(0, 3)];
    }

    public string GetPet()
    {
        return ResumeGenerator.Instance
            .CategoryDataMap[Category.Pet]
            .PossibleAnswers[Random.Range(0, 3)];
    }

    public string GetHobby()
    {
        return ResumeGenerator.Instance
            .CategoryDataMap[Category.Hobby]
            .PossibleAnswers[Random.Range(0, 3)];
    }


    public string GetHometown()
    {
        return ResumeGenerator.Instance
            .CategoryDataMap[Category.HomeTown]
            .PossibleAnswers[Random.Range(0, 3)];
    }

    public string GetFavoriteFood()
    {
        return ResumeGenerator.Instance
            .CategoryDataMap[Category.FavouriteFood]
            .PossibleAnswers[Random.Range(0,3)];
    }
}
