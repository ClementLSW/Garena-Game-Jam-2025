
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Resume
{
    public class CategoryData : MonoBehaviour
    {
        public List<string> PossibleAnswers { get; private set; }
        public List<string> PossiblePrompts { get; private set; }
        public CategoryData(List<string> possibleAnswers, List<string> possiblePrompts)
        {
            PossibleAnswers = possibleAnswers;
            PossiblePrompts = possiblePrompts;
        }
    }
}