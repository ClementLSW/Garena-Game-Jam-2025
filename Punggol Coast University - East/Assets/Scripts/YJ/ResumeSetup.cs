using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResumeSetup : MonoBehaviour
{
    List<int> ySlot = new();
    [SerializeField] List<GameObject> bentos;
    [SerializeField] GameObject superpowerBento;
    List<GameObject> slottedBento = new();
    [SerializeField] List<Transform> bentoSlotsY0, bentoSlotsY1, bentoSlotsY2, bentoSlotsPureY;
    [SerializeField] TextMeshProUGUI funFactTMP, familyTMP, superpowerTMP;
    private void Start()
    {
        //Setup superpowers (long)
        var superpowerSlot = Random.Range(0, 3);
        //Place superpower Gameobject
        superpowerBento.transform.position = bentoSlotsPureY[superpowerSlot].position;
        switch (superpowerSlot)
        {
            case 0:
                //Setup slots 1 and 2
                for (int i = 0; i < 2; i++)
                {
                    var randomBento = Random.Range(0, bentos.Count);
                    //x Slot 1
                    bentos[randomBento].transform.position = bentoSlotsY1[i].position;
                    slottedBento.Add(bentos[randomBento]);
                    bentos.Remove(bentos[randomBento]);
                }

                for (int i = 0; i < 2; i++)
                {
                    var randomBento = Random.Range(0, bentos.Count);
                    //x Slot 1
                    bentos[randomBento].transform.position = bentoSlotsY2[i].position;
                    slottedBento.Add(bentos[randomBento]);
                    bentos.Remove(bentos[randomBento]);
                }
                break;
            case 1:
                //Setup slots 0 and 2
                for (int i = 0; i < 2; i++)
                {
                    var randomBento = Random.Range(0, bentos.Count);
                    //x Slot 1
                    bentos[randomBento].transform.position = bentoSlotsY0[i].position;
                    slottedBento.Add(bentos[randomBento]);
                    bentos.Remove(bentos[randomBento]);
                }

                for (int i = 0; i < 2; i++)
                {
                    var randomBento = Random.Range(0, bentos.Count);
                    //x Slot 1
                    bentos[randomBento].transform.position = bentoSlotsY2[i].position;
                    slottedBento.Add(bentos[randomBento]);
                    bentos.Remove(bentos[randomBento]);
                }
                break;
            case 2:
                //Setup slots 0 and 1
                for (int i = 0; i < 2; i++)
                {
                    var randomBento = Random.Range(0, bentos.Count);
                    //x Slot 1
                    bentos[randomBento].transform.position = bentoSlotsY0[i].position;
                    slottedBento.Add(bentos[randomBento]);
                    bentos.Remove(bentos[randomBento]);
                }

                for (int i = 0; i < 2; i++)
                {
                    var randomBento = Random.Range(0, bentos.Count);
                    //x Slot 1
                    bentos[randomBento].transform.position = bentoSlotsY1[i].position;
                    slottedBento.Add(bentos[randomBento]);
                    bentos.Remove(bentos[randomBento]);
                }
                break;
        }

        //funFactFoodTMP.text = ResumeGenerator.Instance.GetResumeData.FavoriteFood;
        var randomFunFact = Random.Range(0, 6);
        switch (randomFunFact)
        {
            case 0:
        funFactTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Hobby}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.FavoriteFood}\n\n<mark=#000000>{GenerateRandomPaddedString()}";
                break;
            case 1:
        funFactTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.FavoriteFood}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Hobby}\n\n<mark=#000000>{GenerateRandomPaddedString()}";
                break;
            case 2:
        funFactTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.FavoriteFood}\n\n<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Hobby}";
                break;
            case 3:
        funFactTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Hobby}\n\n<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.FavoriteFood}";
                break;
            case 4:
        funFactTMP.text = $"<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Hobby}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.FavoriteFood}";
                break;
            case 5:
        funFactTMP.text = $"<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.FavoriteFood}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Hobby}";
                break;
        }

        var randomFamily = Random.Range(0, 3);
        switch (randomFamily)
        {
            case 0:
                familyTMP.text = $"<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Pet}";
                break;
            case 1:
                familyTMP.text = $"<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Pet}\n\n<mark=#000000>{GenerateRandomPaddedString()}";
                break;
            case 2:
                familyTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Pet}\n\n<mark=#000000>{GenerateRandomPaddedString()}\n\n<mark=#000000>{GenerateRandomPaddedString()}";
                break;
        }

        var randomSuperpower = Random.Range(0, 4);
        switch (randomSuperpower)
        {
            /*            case 0:
                            superpowerTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Superpower} <mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Weakness} <mark=#000000>{GenerateRandomLongPaddedString()}";
                            break;
                        case 1:
                            superpowerTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Weakness} <mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Superpower} <mark=#000000>{GenerateRandomLongPaddedString()}";
                            break;*/
            case 0:
                superpowerTMP.text = $"<mark=#000000>{GenerateRandomLongPaddedString()}<mark=#00000000> {ResumeGenerator.Instance.GetResumeData.Weakness} <mark=#000000>{GenerateRandomLongPaddedString()}<mark=#00000000> {ResumeGenerator.Instance.GetResumeData.Superpower}";
                break;
            case 1:
                superpowerTMP.text = $"<mark=#000000>{GenerateRandomLongPaddedString()}<mark=#00000000> {ResumeGenerator.Instance.GetResumeData.Superpower} <mark=#000000>{GenerateRandomLongPaddedString()}<mark=#00000000> {ResumeGenerator.Instance.GetResumeData.Weakness}";
                break;
            case 2:
                superpowerTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Weakness} <mark=#000000>{GenerateRandomLongPaddedString()}<mark=#00000000> {ResumeGenerator.Instance.GetResumeData.Superpower}";
                break;
            case 3:
                superpowerTMP.text = $"<mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Superpower} <mark=#000000>{GenerateRandomLongPaddedString()}<mark=#00000000> {ResumeGenerator.Instance.GetResumeData.Weakness}";
                break;
/*            case 4:
                superpowerTMP.text = $"<mark=#000000>{GenerateRandomLongPaddedString()} <mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Superpower} <mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Weakness}";
                break;
            case 5:
                superpowerTMP.text = $"<mark=#000000>{GenerateRandomLongPaddedString()} <mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Weakness} <mark=#00000000>{ResumeGenerator.Instance.GetResumeData.Superpower}";
                break;*/
        }
    }

    string GenerateRandomPaddedString()
    {
        var randomPadding = Random.Range(10, 20);
        string padded = "".PadLeft(randomPadding, '0');
        return padded;
    }

    string GenerateRandomLongPaddedString()
    {
        var randomPadding = Random.Range(60, 80);
        string padded = "".PadLeft(randomPadding, '0');
        return padded;
    }
}
