# Siya's Cybersecurity Chatbot

## Overview

This project is a C# console-based chatbot designed to educate users about cybersecurity in an interactive and user-friendly way. The application simulates a conversation between a user and a bot, where the bot provides guidance on staying safe online. It focuses on practical topics such as phishing, password security, suspicious links, safe browsing, and reporting cybercrime, particularly in a South African context.

---

## Core Functionality

The chatbot works by taking user input, processing it, and returning a response based on keyword matching. It does not use artificial intelligence or machine learning; instead, it relies on structured logic and conditional checks to determine appropriate replies.

The program runs in a continuous loop, allowing the user to ask multiple questions until they choose to exit.

---

## Main Components

### 1. Program Class

This is the entry point of the application and controls the overall flow.

Key responsibilities:

* Displays the chatbot interface, including a title and ASCII logo
* Plays an audio greeting at startup
* Prompts the user for their name and validates it using regular expressions
* Starts and manages the main chat loop
* Handles user input and exit conditions
* Adds visual enhancements such as typing effects, colored text, and a loading animation

The `StartChat` method is central to the interaction, repeatedly:

1. Accepts user input
2. Sends it to the chatbot logic
3. Displays the response

---

### 2. Chatbot Class

This class contains all the conversational logic and acts as the decision-making component of the system.

Key responsibilities:

* Processes user input by converting it to lowercase for consistent comparison
* Detects user intent using keyword matching
* Identifies emotional tone (e.g., confusion, fear, frustration) and responds supportively
* Routes input to specific topic handlers based on keywords

Supported topics include:

* Phishing
* Passwords
* Suspicious links
* Safe browsing
* Reporting cybercrime
* General cybersecurity concepts

Each topic is handled by a dedicated method (e.g., `GetPhishingResponse`, `GetPasswordResponse`) that further analyzes the query and returns a detailed explanation.

If the input does not match any known pattern, a default response prompts the user to rephrase or choose a topic.

---

### 3. User Class

This class is used to store and manage user-specific data during the session.

It tracks:

* The user’s name
* Whether the user wants to exit the application
* The session start time
* The number of questions asked

It also includes methods to increment the question count and calculate how long the user has been interacting with the chatbot.

---

## Input Handling and Validation

The program ensures that the user enters a valid name by:

* Checking that the input is not empty
* Ensuring it contains only letters and spaces using a regular expression

During the chat, it also prevents empty messages and prompts the user to enter meaningful input.

---

## Interaction Flow

1. The application starts and plays an audio greeting
2. The user is prompted to enter their name
3. The chatbot welcomes the user and displays available topics
4. The user enters a message
5. The chatbot:

   * Detects emotion or topic using keywords
   * Generates a response
6. The response is displayed with a typing effect
7. The loop continues until the user types "exit"

---

## Additional Features

* **Audio Playback**: A `.wav` file is played at startup using `SoundPlayer`
* **Typing Effect**: Text is displayed character-by-character to simulate natural conversation
* **Loading Animation**: A progress bar gives the impression that the bot is processing input
* **Colored Console Output**: Improves readability and user experience

---

## Limitations

* The chatbot relies entirely on keyword matching, which limits flexibility in understanding complex or unexpected input
* The audio file path is hardcoded and may need adjustment on different systems
* It is a console application, so it does not include a graphical user interface

---

## Conclusion

This chatbot demonstrates how fundamental programming concepts such as classes, methods, loops, and conditional logic can be combined to create an interactive educational tool. While simple in design, it effectively introduces users to essential cybersecurity practices in an accessible and structured manner.
