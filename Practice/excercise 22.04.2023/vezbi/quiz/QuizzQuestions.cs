using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    public static class QuizzQuestions
    {
        public static Question[] Questions { get;private set; }

        public static void SetGeographyQuestions()
        {
            Questions = new Question[]
            {
                new Question(
                    "What is the name of the tallest mountain in the world?",
                    "Mount Everest",
                    new string[]{"Himalayas","Mount Everest","Alps", "Lhotse" }),
                new Question(
                    "What is the biggest continent of the world?",
                    "Asia",
                    null
                    )
            };

        }

        public static void SetMathsQuestions()
        {
            Questions = new Question[]
            {
                new Question(
                    "121 Divided by 11 is",
                    "11",
                    new string[]{"11", "10", "19", "18"}),
                new Question(
                    "60 Times of 8 Equals to",
                    "480",
                    new string[]{"300", "250", "480", "400"}),
                new Question(
                    "What is the Next Prime Number after 7 ?",
                    "11",
                    new string[]{"13", "12", "14", "11"})
            };
        }
    }
}
