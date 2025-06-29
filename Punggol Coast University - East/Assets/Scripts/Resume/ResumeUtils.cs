using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static ResumeGenerator;

namespace Assets.Scripts.Resume
{
    public static class ResumeUtils
    {

        public static string GetAnswerForCategory(ResumeData resume, Category category)
        {
            return category switch
            {
                Category.Superpower => resume.unfluffedSuperpower,
                Category.Weakness => resume.unfluffedWeakness,
                Category.Pet => resume.unfluffedPet,
                Category.Hobby => resume.unfluffedHobby,
                Category.HomeTown => resume.unfluffedHometown,
                Category.FavouriteFood => resume.unfluffedFavoriteFood,
                _ => string.Empty
            };
        }

        public static string GetPromptForCategory(ResumeGenerator generator, Category category)
        {
            return generator.CategoryDataMap[category].PossiblePrompts[Random.Range(0, generator.CategoryDataMap[category].PossiblePrompts.Count)];
        }
    }
}