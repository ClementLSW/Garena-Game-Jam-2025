using Assets.Scripts.Resume;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGenerator : MonoBehaviour
{

    public struct ResumeData
    {
        //public string HeroName;
        //public string GovtName;
        //public Sprite Avatar;
        //public int Age;
        //public int DebutYear;
        //public int CrimeStopped;
        //public int PowersUsed;
        //public string Height;
        //public string Weight;

        public string Superpower;
        public string Weakness;

        public string Pet;
        public string Hobby;
        public string Hometown;
        public string FavoriteFood;
    }
    private ResumeData _data;
    public ResumeData GetResumeData
    {
        get
        {
            return _data;
        }
    }

    // This script is responsible for generating a resume and populating the Data.
    private static ResumeGenerator _instance;
    private ResumeDataDeserializer deserializer;

    public static ResumeGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ResumeGenerator>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("ResumeGenerator");
                    _instance = obj.AddComponent<ResumeGenerator>();
                }
            }
            return _instance;
        }
    }

    public Dictionary<Category, CategoryData> CategoryDataMap { get; private set; }

    private void InitializeCategoryData()
    {
        CategoryDataMap = new Dictionary<Category, CategoryData>();

        CategoryDataMap[Category.FavouriteFood] = new CategoryData(
            new List<string> {
                "<color=red>pizza</color>",
                "<color=red>sushi</color>",
                "<color=red>ramen</color>"
            },
            new List<string> {
                "After a long day, i go home and eat what?",
                "My all time favourite food is?",
                "What is my favourite Dinner?"
            }
            );

        CategoryDataMap[Category.HomeTown] = new CategoryData(
            new List<string>
            {
                "<color=red>New York</color>",
                "<color=red>Los Angeles</color>",
                "<color=red>Chicago</color>"
            },
            new List<string>
            {
                "Where did I grow up?",
                "What is my hometown?",
                "Where do I call home?"
            }
            );

        CategoryDataMap[Category.Hobby] = new CategoryData(
            new List<string>
            {
                "<color=red>knitting</color>",
                "<color=red>reading books</color>",
                "<color=red>playing video games</color>"
            },
            new List<string>
            {
                "What do I like to do in my free time?",
                "What is my favourite hobby?",
                "What do I enjoy doing?"
            }
            );

        CategoryDataMap[Category.Pet] = new CategoryData(
            new List<string>
            {
                "<color=red>dog</color>",
                "<color=red>cat</color>",
                "<color=red>parrot</color>"
            },
            new List<string>
            {
                "What is my pet?",
                "What animal do I have?",
                "What is my beloved pet?"
            }
            );
        CategoryDataMap[Category.Superpower] = new CategoryData(
            new List<string>
            {
                "<color=red>invisibility</color>",
                "<color=red>super strength</color>",
                "<color=red>flight</color>"
            },
            new List<string>
            {
                "What is my superpower?",
                "What can I do that others can't?",
                "What is my unique ability?"
            }
            );
        CategoryDataMap[Category.Weakness] = new CategoryData(
            new List<string>
            {
                "<color=red>Kryptonite</color>",
                "<color=red>fear of heights</color>",
                "<color=red>overthinking</color>"
            },
            new List<string>
            {
                "What is my weakness?",
                "What can defeat me?",
                "What is my Achilles' heel?"
            }
            );
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Duplicate ResumeGenerator instance found. Destroying.");
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        deserializer = new ResumeDataDeserializer();
        InitializeCategoryData();
        GenerateData();
    }

    public void GenerateData()
    {
        ResumeData temp = new ResumeData
        {
            //HeroName = deserializer.GetHeroName(),
            //GovtName = deserializer.GetGovtName(),
            //Age = deserializer.GetAge(),
            //Avatar = deserializer.GetSprite(),
            //Height = deserializer.GetHeight(),
            //Weight = deserializer.GetWeight()
            Superpower = DataFluff(Category.Superpower),
            Weakness = DataFluff(Category.Weakness),
            Pet = DataFluff(Category.Pet),
            Hobby = DataFluff(Category.Hobby),
            Hometown = deserializer.GetHometown(),
            FavoriteFood = DataFluff(Category.FavouriteFood),
        };

        _data = temp;
        QuestionInstance.Instance.GenerateAllQuestions();
    }

    public string DataFluff(Category cat)
    {
        int rng = Random.Range(0, 3);

        switch (cat)
        {
            case Category.Superpower:
                string temp = deserializer.GetPower();

                return rng switch
                {
                    0 => "My superpower is " + temp + ".",
                    1 => "I have the ability of " + temp + ".",
                    2 => "Blessed with the power of " + temp + ",",
                    _ => "My superpower is " + temp + ".",
                };

            case Category.Weakness:
                string tempWeakness = deserializer.GetWeakness();

                return rng switch
                {
                    0 => tempWeakness + " is the one thing that haunts me.",
                    1 => "I struggle with " + tempWeakness + ".",
                    2 => "Above all, " + tempWeakness + " scares me the most.",
                    _ => "My weakness is " + tempWeakness + ".",
                };

            case Category.Pet:
                string tempPet = deserializer.GetPet();

                return rng switch
                {
                    0 => "I have a pet " + tempPet + ".",
                    1 => "My beloved pet is a " + tempPet + ".",
                    2 => "My " + tempPet + " is my ride or die.",
                    _ => "I have a pet " + tempPet + ".",
                };

            case Category.Hobby:
                string tempHobby = deserializer.GetHobby();

                return rng switch
                {
                    0 => "In my free time, I enjoy " + tempHobby + ".",
                    1 => "You can find me " + tempHobby + " when I have some downtime.",
                    2 => tempHobby + " is my favourite past time.",
                    _ => "In my free time, I enjoy " + tempHobby + ".",
                };

            case Category.FavouriteFood:
                string tempFood = deserializer.GetFavoriteFood();

                return rng switch
                {
                    0 => "My favourite food is " + tempFood + ".",
                    1 => "I love to eat " + tempFood + ".",
                    2 => "You can always find me eating " + tempFood + ".",
                    _ => "My favourite food is " + tempFood + ".",
                };
        }

        return string.Empty; // Fallback in case of an unexpected category
    }
}
