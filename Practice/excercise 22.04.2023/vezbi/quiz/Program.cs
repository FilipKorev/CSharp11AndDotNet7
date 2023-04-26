//bonus dodadete opcija na userot da odbere kategorija
using quiz;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
do
{
    string x = Options.QOptions();
    if (x == "geography")
    {
        QuizzQuestions.SetGeographyQuestions();
    }
    else if (x == "maths")
    {
        QuizzQuestions.SetMathsQuestions();
    }else
    {
        Console.WriteLine("eh :D");
    }


    //QuizzQuestions.SetGeographyQuestions();

    foreach (Question question in QuizzQuestions.Questions)
    {
        Console.WriteLine(question.Text);
        for (int i = 0; i < question.Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Options[i]}");
        }
        string userAnswer = Console.ReadLine().Trim();
        if (userAnswer.ToLower() == question.Answer.ToLower())
        {
            Console.WriteLine("You quessed right");
        }
        else
        {
            Console.WriteLine($"The right answer was {question.Answer}");
        }
        Console.WriteLine();
    }

    Console.WriteLine("Would you like to play again? yes/no");
    string newGame = Console.ReadLine();
    
} while (true);