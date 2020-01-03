using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace StartNewGame
{
    public class Question
    {
        readonly int[] prize = new int[] { 500, 1000, 2000, 5000, 10000, 20000, 50000, 75000, 150000, 250000, 500000, 1000000 }; //amount to be won
        public enum DifficultyLevel { Easy = 0, Normal = 1, Hard = 2 };
        public DifficultyLevel difficulty = new DifficultyLevel();
        public string questionCategory; //category of question
        public string questionContent; //the content of the question
        public string a, b, c, d; //4 possible answers
        public string correctAnswer; //one correct answer
        public string playerAnswer; //answer given by player
        public bool isAnswerCorrect; //flag if player gave the correct answer
        public bool isAnswerValid; //flag if the answer is acceptable (i.e. a or b or c or d)

        //load question with <QuestionID> ID number from <fName> text file
        public void loadQuestion(string fName, int questionID)
        {
            try
            {
                using (StreamReader file = new StreamReader(fName))
                {
                    int StartingLineNumber = questionID * 7 + 1;
                    int counter = 1;
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (counter == StartingLineNumber) questionCategory = line;
                        else if (counter == StartingLineNumber + 1) questionContent = line;
                        else if (counter == StartingLineNumber + 2) a = line;
                        else if (counter == StartingLineNumber + 3) b = line;
                        else if (counter == StartingLineNumber + 4) c = line;
                        else if (counter == StartingLineNumber + 5) d = line;
                        else if (counter == StartingLineNumber + 6) correctAnswer = line;
                        counter++;
                    }
                    file.Close();


                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void displayQuestion(int questionID)
        {
            Console.WriteLine($"Question number: {questionID + 1} ");
            Console.WriteLine($"Question difficulty: {difficulty}");
            Console.WriteLine($"Question for {prize[questionID]} $");
            Console.WriteLine("Category: " + questionCategory);
            Console.WriteLine(questionContent);
            Console.WriteLine("A: " + a);
            Console.WriteLine("B: " + b);
            Console.WriteLine("C: " + c);
            Console.WriteLine("D: " + d);
            Console.WriteLine("\n");
            Console.WriteLine("Your answer:");
        }
        void readAnswer()
        {
            playerAnswer = Console.ReadLine();
            playerAnswer = playerAnswer.ToUpper();
            
        }
        void validateAnswer(string answer)
        {
            if (answer == "A" || answer == "B" || answer == "C" || answer == "D") isAnswerValid = true;
            else isAnswerValid = false;
        }

        void checkAnswer(string answer)
        {
            if (answer == correctAnswer)
            {
                isAnswerCorrect = true;
            }
            else
            {
                isAnswerCorrect = false;
            }
        }
        public void getAnswerFromUser()
        {
            do
            {
                readAnswer();
                validateAnswer(playerAnswer);
                if (isAnswerValid == false) Console.WriteLine("There is no such answer Correct answers are: A, B, C, D!\nYour answer:");
            } while (isAnswerValid == false);
            checkAnswer(playerAnswer);
        }
    }
}
