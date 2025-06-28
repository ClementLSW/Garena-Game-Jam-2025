using System.Collections;
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
                Category.Superpower => resume.Superpower,
                Category.Weakness => resume.Weakness,
                Category.Pet => resume.Pet,
                Category.Hobby => resume.Hobby,
                Category.HomeTown => resume.Hometown,
                Category.FavouriteFood => resume.FavoriteFood,
                _ => string.Empty
            };
        }
    }
}