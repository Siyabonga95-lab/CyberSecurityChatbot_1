using System;

namespace CyberSecurityChatbot_1
{
  
    // USER CLASS - This stores information about the person using my chatbot
    // I use this to remember the user's name and track their activity
   
    public class User
    {
        // ========================================================
        // PROPERTIES - These are like containers that hold information
        // ========================================================

        // This stores the user's name so I can use it throughout the program
        public string Name { get; set; }

        // This tracks whether the user wants to exit the chatbot
        // When true, the main loop will stop
        public bool IsExiting { get; set; }

        // This records when the user started using the chatbot
        // I use this to calculate how long they've been learning
        public DateTime StartTime { get; set; }

        // This counts how many questions the user has asked
        // I could use this for statistics or encouragement
        public int QuestionCount { get; set; }

        // ========================================================
        // CONSTRUCTOR - This runs when I create a new User object
        // ========================================================
        // The constructor takes the user's name as a parameter
        public User(string name)
        {
            // I save the name in the Name property
            Name = name;
            // User is not exiting yet
            IsExiting = false;
            // I record the current date and time
            StartTime = DateTime.Now;
            // No questions asked yet
            QuestionCount = 0;
        }

        // ========================================================
        // INCREMENT QUESTIONS - This adds 1 to the question counter
        // ========================================================
        // I call this method every time the user asks a question
        public void IncrementQuestions()
        {
            QuestionCount++;
        }

        // ========================================================
        // GET SESSION TIME - This calculates how long they've been using the chatbot
        // ========================================================
        // I subtract the start time from the current time
        public string GetSessionTime()
        {
            // I calculate the time difference
            TimeSpan time = DateTime.Now - StartTime;
            // I return a string that shows minutes and seconds
            return $"{time.Minutes} min, {time.Seconds} sec";
        }
    }
}