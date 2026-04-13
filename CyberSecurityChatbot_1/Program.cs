using System;
using System.Media;      // This helps me play sound files
using System.Threading;  // This helps me add delays and animations
using System.IO;         // This helps me check if files exist
using System.Text.RegularExpressions; // This helps me check for letters only

namespace CyberSecurityChatbot_1
{
    class Program
    {
      
        // MAIN METHOD - This is where my program starts running
  
        static void Main(string[] args)
        {
            // I set the title that appears on the console window
            Console.Title = "SIYA'S CYBER CHATBOT";

            // I play the voice greeting first (before anything else shows)
            PlayVoiceGreeting();
            // I wait half a second so the sound can start playing
            Thread.Sleep(500);

            // I clear the console screen for a clean look
            Console.Clear();
            // I show my ASCII art logo
            DisplayLogo();

            // ========================================================
            // GET USER'S NAME - I check that it contains only letters
            // ========================================================
            string name = "";
            bool validName = false;

            // I keep asking until the user gives a valid name
            while (!validName)
            {
                Console.Write("Bot: Hi! What's your name? ");
                name = Console.ReadLine();

                // I check if the name is empty
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Bot: Please tell me your name - it can't be empty!\n");
                }
                // I check if the name contains only letters and spaces
                else if (!IsValidName(name))
                {
                    Console.WriteLine("Bot: Please enter a real name using only letters (no numbers or symbols like @#$%!)\n");
                }
                else
                {
                    // Name is valid, I can continue
                    validName = true;
                }
            }

            // I create a User object to store their information
            User user = new User(name);

            // I clear screen and show logo again for a fresh start
            Console.Clear();
            DisplayLogo();

            // I welcome the user with a typing effect (feels more personal)
            TypeText($"Bot: Hello {user.Name}!  Welcome to my Cybersecurity Chatbot.\n", 40);
            TypeText("Bot: I'm here to help you stay safe online!\n\n", 40);
            // I pause briefly so the message sinks in
            Thread.Sleep(500);

            // I start the main conversation
            StartChat(user);
        }

        // ============================================================
        // IS VALID NAME - This checks if a name has only letters and spaces
        // I use Regex to make sure there are no numbers or symbols
        // ============================================================
        static bool IsValidName(string name)
        {
            // I trim the name to remove extra spaces at the start or end
            name = name.Trim();

            // I check if the name is empty after trimming
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // I use Regex to check if the name contains ONLY letters and spaces
            // ^ means start, [a-zA-Z] means letters A-Z and a-z, spaces allowed, + means one or more, $ means end
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        // ============================================================
        // DISPLAY LOGO - This shows my ASCII art
        // I made this box to make my chatbot look cool
        // ============================================================
        static void DisplayLogo()
        {
            // I change text color to cyan for the art
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   ╔════════════════════════════════════╗
   ║     SIYA'S CYBER CHATBOT           ║
   ║     Stay Safe Online!              ║
   ╚════════════════════════════════════╝
            ");
            // I reset color back to normal
            Console.ResetColor();
        }

        // ============================================================
        // TYPE TEXT - This makes the bot type letter by letter
        // It feels more like a real person is talking to you
        // ============================================================
        static void TypeText(string text, int delay = 40)
        {
            // I loop through each character in the text
            foreach (char c in text)
            {
                Console.Write(c);        // I print one letter
                Thread.Sleep(delay);     // I wait a tiny bit before the next letter
            }
        }

        // ============================================================
        // SHOW LOADING - This creates a progress bar from 0% to 100%
        // It makes the user feel like I'm thinking about their question
        // ============================================================
        static void ShowLoading(int duration = 1200)
        {
            // I show "Bot is thinking" with animated dots
            Console.Write("Bot is thinking");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine();

            // I create a progress bar with 20 blocks
            Console.Write("[");
            for (int i = 0; i <= 20; i++)
            {
                Console.Write("█");          // I print a filled block
                Thread.Sleep(duration / 20); // I wait before printing the next block
            }
            Console.WriteLine("] 100%\n");
            // I pause so the user sees the bar before I answer
            Thread.Sleep(300);
        }

        // ============================================================
        // PLAY VOICE GREETING - This plays my WAV file
        // I use PlaySync() so the sound finishes before continuing
        // ============================================================
        static void PlayVoiceGreeting()
        {
            try
            {
                // I create a SoundPlayer with my WAV file
                SoundPlayer player = new SoundPlayer(@"C:\Users\Student\source\repos\CybersecurityChatbot\CybersecurityChatbot\Chatbot.wav");
                // I play the sound and wait for it to finish
                player.PlaySync();
            }
            catch (Exception)
            {
                // If sound fails, I just continue - program still works
            }
        }

        // ============================================================
        // START CHAT - This is the main loop where we talk
        // ============================================================
        static void StartChat(User user)
        {
            // I create a Chatbot object to handle all the responses
            Chatbot bot = new Chatbot();

            // I show the user what topics I can help with
            TypeText("Bot:  I can teach you about:\n", 40);
            // I change to green for the topic list
            Console.ForegroundColor = ConsoleColor.Green;
            TypeText("  • PHISHING - Spot fake emails\n", 40);
            TypeText("  • PASSWORDS - Create strong ones\n", 40);
            TypeText("  • SUSPICIOUS LINKS - Don't get tricked\n", 40);
            TypeText("  • SAFE BROWSING - Stay safe online\n", 40);
            TypeText("  • REPORTING - Where to report scams\n", 40);
            TypeText("  • CYBERSECURITY - What it is\n\n", 40);
            Console.ResetColor();

            // I give the user tips on how to use the chatbot
            TypeText("Bot: Type 'menu' to see topics, 'exit' to quit\n\n", 40);

            // I keep chatting until the user wants to exit
            while (!user.IsExiting)
            {
                // I show the user's name in dark red so they know it's their turn
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{user.Name}: ");
                Console.ResetColor();

                // I read what the user typed
                string input = Console.ReadLine();

                // I check if the user wants to exit
                if (input.ToLower() == "exit")
                {
                    // I change to magenta for the goodbye message
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    TypeText($"\nBot: Goodbye {user.Name}! Stay safe online! \n", 40);
                    user.IsExiting = true;
                    break;
                }

                // I check if the user didn't type anything
                if (string.IsNullOrWhiteSpace(input))
                {
                    TypeText("Bot: Please type something so I can help you!\n\n", 40);
                    continue; // I go back to the start of the loop
                }

                // I count how many questions they've asked
                user.IncrementQuestions();
                // I show a loading animation before I answer
                ShowLoading();

                // I get the chatbot's response by calling GetResponse
                // I pass in what they said and their name
                string response = bot.GetResponse(input, user.Name);

                // I show the bot's response in blue with typing effect
                Console.ForegroundColor = ConsoleColor.Blue;
                TypeText($"Bot: {response}\n\n", 42);
                Console.ResetColor();
            }
        }
    }
}