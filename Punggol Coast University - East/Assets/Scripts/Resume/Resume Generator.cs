using UnityEngine;

public class ResumeGenerator : MonoBehaviour
{

    public struct ResumeData
    {
        public string HeroName;
        public string GovtName;
        public Sprite Avatar;
        public int Age;
        public int DebutYear;
        public int CrimeStopped;
        public int PowersUsed;
        public string Height;
        public string Weight;
        
        public string Power;
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
    }

    public void GenerateData()
    {
        ResumeData temp = new ResumeData
        {
            HeroName = deserializer.GetHeroName(),
            GovtName = deserializer.GetGovtName(),
            Age = deserializer.GetAge(),
            Avatar = deserializer.GetSprite(),
            Power = deserializer.GetPower(),
            Pet = deserializer.GetPet(),
            Hobby = deserializer.GetHobby(),
            Weakness = deserializer.GetWeakness(),
            Hometown = deserializer.GetHometown(),
            FavoriteFood = deserializer.GetFavoriteFood(),
            Height = deserializer.GetHeight(),
            Weight = deserializer.GetWeight()
        };
        
        _data = temp;
    }
}
