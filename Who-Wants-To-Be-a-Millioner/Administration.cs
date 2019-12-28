using System;
namespace WhoWantsToBeaMillioner
{
    public class Administration
    {
        private string administraionPassword = "1234";


        public bool checkPassword(string password)
        {
            int result = string.Compare(administraionPassword, password);
            if(result >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string[] getAllQuestions()
        {
            String[] example = new String[] {""};
            return example;
        }

        public void viewAndEditQuestion(int categoryOfQuestion, int questionId)
        {

        }

        public void addNewQuestion(int category, int difficultyLevel, string contentOfTheQuestion, int correctAnswer, string[] allAnswers)
        {

        }

        public string removeQuestion(int difficultyLevel, int questionId)
        {


            // question will return back
            return "";
        }
    }
}
