using System;

namespace CyberSecurityChatbot_1
{
    // CHATBOT CLASS - This is where all the conversation logic lives
    // This is the brain of my chatbot - it decides what to say
    public class Chatbot
    {
      
        // GET RESPONSE - This is the main method that gets called for every user message
     
        // I check what the user said and return an appropriate response
        public string GetResponse(string input, string userName)
        {
            // I convert the input to lowercase so it's easier to compare
            // This way "PhIsHiNg" and "phishing" both work the same
            string msg = input.ToLower();

            // EMOTIONAL RESPONSES - 6 emotions + bot's own feelings
            // I only respond to emotions if the user mentions them


            // Emotion 1: User is confused or lost
            // I use .Contains() to check if any of these words appear in what the user said
            if (msg.Contains("confused") || msg.Contains("don't understand") || msg.Contains("lost"))
            {
                return $"Aww {userName}, it's okay to be confused!  Cybersecurity has a lot to learn. Just tell me what part you don't get and I'll explain it simply. We'll figure it out together! ";
            }

            // Emotion 2: User is scared, worried, nervous, or afraid
            if (msg.Contains("scared") || msg.Contains("worried") || msg.Contains("nervous") || msg.Contains("afraid"))
            {
                return $"I hear you {userName}.  It can be scary hearing about cyber attacks. But here's good news: by learning this, you're getting STRONGER! Knowledge is power, and you're building your shield right now. You've got this! ";
            }

            // Emotion 3: User is happy, excited, awesome, or great
            if (msg.Contains("happy") || msg.Contains("excited") || msg.Contains("awesome") || msg.Contains("great"))
            {
                return $"That's awesome {userName}!  I love your energy! Learning about cybersecurity is fun when we do it together. What would you like to learn about today? ";
            }

            // Emotion 4: User is sad, down, upset, or having a bad day
            if (msg.Contains("sad") || msg.Contains("down") || msg.Contains("upset") || msg.Contains("bad day"))
            {
                return $"Aww {userName}, sorry you're feeling down.  Maybe learning something new might help? I'm here to teach you about staying safe online - it might make you feel stronger. Want to give it a try? ";
            }

            // Emotion 5: User is angry, frustrated, mad, or annoyed
            if (msg.Contains("angry") || msg.Contains("frustrated") || msg.Contains("mad") || msg.Contains("annoyed"))
            {
                return $"I hear you {userName}.  It can be frustrating dealing with all this security stuff. Take a deep breath! Let's learn together in a simple way. What would you like to know? I'll make it easy for you! ";
            }

            // Emotion 6: User is tired, exhausted, sleepy, or overwhelmed
            if (msg.Contains("tired") || msg.Contains("exhausted") || msg.Contains("sleepy") || msg.Contains("overwhelmed"))
            {
                return $"Take a break if you need to {userName}!  Cybersecurity is a lot to take in. When you're ready, I'll be here. Maybe just one small topic for now? What would you like to learn? ";
            }

            // BOT'S OWN FEELINGS - When user asks how the bot is doing
            // I use .Contains() to check for different ways of asking "how are you"
            if (msg.Contains("how are you") || msg.Contains("how you doing") || msg.Contains("how you feeling") || msg.Contains("you okay"))
            {
                // I create an array of possible responses
                string[] feelings = {
                    $"I'm doing great {userName}!  Thanks for asking! I love helping people learn about cybersecurity. It makes me happy! ",
                    $"I'm wonderful today {userName}!  Nothing makes me happier than teaching someone how to stay safe online. What would you like to learn?",
                    $"I'm super excited {userName}!  Every time someone learns about cybersecurity, the internet gets a little safer. You're awesome for wanting to learn!"
                };
                // I pick a random response so it's not always the same
                Random rand = new Random();
                return feelings[rand.Next(feelings.Length)];
            }

            // User says thank you or thanks - I show appreciation
            if (msg.Contains("thank") || msg.Contains("thanks"))
            {
                return $"You're welcome {userName}!  I'm really happy I could help. Stay safe online! Anything else you want to learn? ";
            }

            // Show menu - I display all the topics I can teach
            if (msg == "menu" || msg == "help")
            {
                return GetMenu();
            }

            // TOPIC RESPONSES - I figure out what the user wants to learn about
            // I use .Contains() to check for keywords in their message
            // This works even if they ask in different ways


            // PHISHING TOPIC - I check for words like phish, scam email, fake email
            // The .Contains() method catches these even if they're in a sentence
            if (msg.Contains("phish") || msg.Contains("scam email") || msg.Contains("fake email"))
            {
                return GetPhishingResponse(msg, userName);
            }

            // PASSWORD TOPIC - I check for password, pass, or login
            if (msg.Contains("password") || msg.Contains("pass") || msg.Contains("login"))
            {
                return GetPasswordResponse(msg, userName);
            }

            // SUSPICIOUS LINKS TOPIC - I check for link, url, or click
            if (msg.Contains("link") || msg.Contains("url") || msg.Contains("click"))
            {
                return GetLinkResponse(msg, userName);
            }

            // SAFE BROWSING TOPIC - I check for browse, internet, website, or web
            if (msg.Contains("browse") || msg.Contains("internet") || msg.Contains("website") || msg.Contains("web"))
            {
                return GetBrowsingResponse(msg, userName);
            }

            // REPORTING TOPIC - I check for report, saps, or police
            if (msg.Contains("report") || msg.Contains("saps") || msg.Contains("police"))
            {
                return GetReportingResponse(msg, userName);
            }

            // CYBERSECURITY TOPIC - I check for cyber, security, what is, or protect
            if (msg.Contains("cyber") || msg.Contains("security") || msg.Contains("what is") || msg.Contains("protect"))
            {
                return GetCyberResponse(msg, userName);
            }

            // Default response - if I don't understand, I ask them to rephrase
            return $"Hmm {userName}, I'm not sure I understood.  Try asking about phishing, passwords, links, browsing, reporting, or cybersecurity. Type 'menu' to see all topics! ";
        }

      
        // GET MENU - This shows all the topics I can teach about
   
        private string GetMenu()
        {
            return "== Here's what I can teach you:\n\n" +
                   " • PHISHING - Spot fake emails and scams\n" +
                   " • PASSWORDS - Create strong, safe passwords\n" +
                   " • SUSPICIOUS LINKS - Don't get tricked\n" +
                   " • SAFE BROWSING - Stay safe on the internet\n" +
                   " • REPORTING - Where to report cybercrime in SA\n" +
                   " • CYBERSECURITY - What it is and why it matters\n\n" +
                   "Just type what you want to learn! Example: 'what is phishing' or 'how to spot phishing'";
        }

       
        // PHISHING RESPONSES - Different ways to ask the same thing
        // I use .Contains() to check what type of question they're asking
        
        private string GetPhishingResponse(string msg, string name)
        {
            // What is phishing? (definition) - I check for "what is", "define", or "meaning"
            if (msg.Contains("what is") || msg.Contains("define") || msg.Contains("meaning"))
            {
                return $"Great question {name}! \n\nPHISHING is when scammers send fake emails pretending to be from real companies like banks, Netflix, or PayPal. They want you to click dangerous links or give away your passwords. The name comes from 'fishing' - they're 'fishing' for your information!\n\nWant to learn how to SPOT phishing emails? Just ask me!";
            }

            // Why does phishing exist? (purpose) - I check for "why", "purpose", or "reason"
            if (msg.Contains("why") || msg.Contains("purpose") || msg.Contains("reason"))
            {
                return $"Good question {name}! \n\nPhishing exists because scammers want to steal:\n YOUR MONEY - by getting bank details\n YOUR IDENTITY - to open accounts in your name\n YOUR ACCOUNTS - to scam your friends\n\nIn South Africa, phishing attacks have increased a lot. That's why learning to spot them is so important! Want to learn HOW to spot them?";
            }

            // How to spot phishing? (identification) - I check for "spot", "identify", "recognize", or "how to know"
            if (msg.Contains("spot") || msg.Contains("identify") || msg.Contains("recognize") || msg.Contains("how to know"))
            {
                return $"You're going to be a pro at this {name}! \n\nHOW TO SPOT PHISHING EMAILS:\n\n1️⃣ Check the sender's email - paypa1.com is FAKE, paypal.com is REAL\n2️⃣ Look for spelling mistakes - scammers have bad grammar\n3️⃣ Watch for URGENT words like 'ACT NOW!' or 'Account Suspended'\n4️⃣ Hover over links without clicking to see where they go\n5️⃣ If it sounds too good to be true, it IS a scam!\n\nReal companies NEVER ask for passwords via email!";
            }

            // Examples of phishing - I check for "example", "sample", "look like", or "show me"
            if (msg.Contains("example") || msg.Contains("sample") || msg.Contains("look like") || msg.Contains("show me"))
            {
                return $"Here are real phishing examples {name}:\n\n Fake Bank: 'URGENT! Your account is locked! Click here to verify'\n Prize Winner: 'You won R10,000! Send your bank details'\n Fake Delivery: 'Your package is waiting. Track here: bit.ly/...'\n Netflix: 'Your account is suspended. Update payment now'\n\n Red flags: Urgent language, asks to click links, asks for personal info!";
            }

            // How to protect yourself - I check for "protect", "prevent", "avoid", or "safe"
            if (msg.Contains("protect") || msg.Contains("prevent") || msg.Contains("avoid") || msg.Contains("safe"))
            {
                return $"Smart question {name}! \n\nHOW TO PROTECT YOURSELF:\n NEVER click links in suspicious emails - type the address yourself\n Use TWO-FACTOR AUTHENTICATION (2FA) - adds extra lock\n Report phishing to report@cybersecurity.gov.za\n When in doubt, CALL the company using their official number\n\nYou're becoming a cybersecurity hero! ";
            }

            // History of phishing - I check for "history", "started", "first", or "origin"
            if (msg.Contains("history") || msg.Contains("started") || msg.Contains("first") || msg.Contains("origin"))
            {
                return $"Interesting question {name}! \n\nThe term 'phishing' started in the 1990s! Hackers would use fake emails to 'fish' for passwords. They used 'ph' instead of 'f' because of 'phreaking' (old phone hacking). Today, phishing is one of the biggest cyber threats worldwide. In South Africa, attacks have increased over 200%!\n\nWant to learn how to SPOT them?";
            }

            // Default phishing response - if they just said "phishing" without a specific question
            return $"I'd love to teach you about phishing {name}! \n\nYou can ask me:\n• 'What is phishing?'\n• 'Why does phishing exist?'\n• 'How to spot phishing?'\n• 'Examples of phishing'\n• 'How to protect myself?'\n\nWhat would you like to know?";
        }

      
        // PASSWORD RESPONSES
       
        private string GetPasswordResponse(string msg, string name)
        {
            // What is password safety?
            if (msg.Contains("what is") || msg.Contains("define"))
            {
                return $"Great question {name}! \n\nA PASSWORD is like a key to your online accounts. Password SAFETY is about creating strong keys that hackers can't guess. Weak password = leaving your front door unlocked!\n\nWant to learn how to CREATE a strong password? Just ask me!";
            }

            // Why are passwords important?
            if (msg.Contains("why") || msg.Contains("important") || msg.Contains("matter"))
            {
                return $"Super important question {name}! \n\nPasswords protect EVERYTHING:\n Your money - bank accounts\n Your email - where password resets go\n Your social media - photos and messages\n Your identity - personal information\n\nIf a hacker gets ONE weak password, they can try it everywhere. That's why strong passwords matter! Want to learn how to make one?";
            }

            // How to create a strong password?
            if (msg.Contains("create") || msg.Contains("make") || msg.Contains("strong") || msg.Contains("how to"))
            {
                return $"Let's make you a password superhero {name}! \n\nHOW TO CREATE A STRONG PASSWORD:\n\n Make it LONG - 12+ characters\n Mix it UP - Use CAPITALS, lowercase, numbers, and symbols\n Use a PASSPHRASE - combine random words like 'Blue-Horse-Sunshine-Rain!'\n Make it UNIQUE - different password for every account\n\nBAD: 'password123' (hackers guess in seconds)\nGOOD: 'MyD0g!sC00l2024'\n\nYou can do this! ";
            }

            // What to avoid in passwords?
            if (msg.Contains("avoid") || msg.Contains("bad") || msg.Contains("mistake") || msg.Contains("dont"))
            {
                return $"Great question {name}! Here's what to AVOID:\n\n DON'T use your name or birthday\n DON'T use 'password123' or 'qwerty'\n DON'T use the same password everywhere\n DON'T write passwords on sticky notes\n DON'T share passwords with friends\n\nAvoid these and you'll be much safer! ";
            }

            // How to manage many passwords?
            if (msg.Contains("manage") || msg.Contains("remember") || msg.Contains("many"))
            {
                return $"I know remembering passwords is HARD {name}! \n\nHere's how smart people manage them:\n\n Use a PASSWORD MANAGER - Apps like Bitwarden or LastPass (they're FREE!)\n   They remember ALL your passwords, you only need ONE master password\n\n Use a PASSPHRASE - 'Green-Mountain-Tea-Time!'\n   Easy to remember, hard to guess\n\n Use TWO-FACTOR AUTHENTICATION (2FA)\n   Even if someone gets your password, they can't get in!\n\nYou're getting smarter every day! ";
            }

            // History of passwords
            if (msg.Contains("history") || msg.Contains("first") || msg.Contains("started"))
            {
                return $"Cool question {name}! \n\nPasswords have been around for THOUSANDS of years! Ancient soldiers used 'watchwords' to identify friends. The first computer password was created in the 1960s at MIT. Today, hackers have super fast computers that can try millions of passwords per second. That's why we need STRONG passwords now!\n\nWant to learn how to create one?";
            }

            // Default password response
            return $"I'd love to teach you about passwords {name}! \n\nYou can ask me:\n• 'What is password safety?'\n• 'Why are passwords important?'\n• 'How to create a strong password?'\n• 'What to avoid in passwords?'\n• 'How to manage many passwords?'\n\nWhat would you like to know?";
        }

    
        // SUSPICIOUS LINKS RESPONSES
       
        private string GetLinkResponse(string msg, string name)
        {
            // What are suspicious links?
            if (msg.Contains("what is") || msg.Contains("define"))
            {
                return $"Great question {name}! \n\nA SUSPICIOUS LINK is one that looks real but actually takes you to a FAKE website. Scammers use them to steal your passwords or install viruses. It's like a sign that says 'BANK' but leads to a dark alley!\n\nWant to learn how to SPOT fake links?";
            }

            // Why do scammers use links?
            if (msg.Contains("why") || msg.Contains("purpose") || msg.Contains("reason"))
            {
                return $"Good question {name}! \n\nScammers use suspicious links to TRICK you:\n To steal your passwords - fake login pages\n To install viruses - malware on your device\n To steal your money - fake shopping sites\n To lock your files - ransomware attacks\n\nThat's why learning to spot them is so important! Want to learn HOW?";
            }

            // How to spot fake links?
            if (msg.Contains("spot") || msg.Contains("fake") || msg.Contains("identify") || msg.Contains("how to know"))
            {
                return $"You're going to be a link detective {name}! \n\nHOW TO SPOT FAKE LINKS:\n\n1️⃣ HOVER over the link (DON'T click!) - see where it REALLY goes\n2️⃣ Look for spelling tricks - faceb00k.com is FAKE, facebook.com is REAL\n3️⃣ Check for 'https://' - the 's' means secure\n4️⃣ Be suspicious of shortened links - bit.ly, tinyurl hide the real address\n5️⃣ Trust your gut - if something feels wrong, DON'T CLICK!\n\nYou've got this! ";
            }

            // How to check if a link is safe?
            if (msg.Contains("check") || msg.Contains("safe") || msg.Contains("verify"))
            {
                return $"Smart question {name}! Here's how to check links safely:\n\n METHOD 1: Use VirusTotal.com - paste the link, it scans for danger\n METHOD 2: Type it yourself - instead of clicking, type the address manually\n METHOD 3: Ask someone - two sets of eyes are better than one\n METHOD 4: Google it - search the website name + 'scam'\n\nYou're learning to be careful and smart! ";
            }

            // What happens if I click a bad link?
            if (msg.Contains("clicked") || msg.Contains("happen") || msg.Contains("what if"))
            {
                return $"It's okay to be worried {name}. \n\nIF YOU CLICK A BAD LINK:\n• Hackers can install viruses\n• They can steal your passwords\n• They could lock your files\n\nWHAT TO DO:\n1️⃣ DISCONNECT from internet immediately\n2️⃣ RUN antivirus scan\n3️⃣ CHANGE your passwords (use a different device)\n4️⃣ CONTACT your bank if you entered card details\n\nThe fact you're learning this means you're already ahead! ";
            }

            // Examples of suspicious links
            if (msg.Contains("example") || msg.Contains("sample") || msg.Contains("show me"))
            {
                return $"Here are fake link examples {name}:\n\n Fake PayPal: Displayed 'paypal.com/login' but goes to 'paypa1.com/login'\n Shortened link: 'bit.ly/2xYz789' - you can't see where it goes!\n Misspelled: 'go0gle.com' instead of 'google.com'\n Extra words: 'fnb-verify.xyz' instead of 'fnb.co.za'\n\nSee the patterns? You'll spot these easily now!";
            }

            // Default link response
            return $"I'd love to teach you about suspicious links {name}! \n\nYou can ask me:\n• 'What are suspicious links?'\n• 'Why do scammers use links?'\n• 'How to spot fake links?'\n• 'How to check if a link is safe?'\n• 'What happens if I click a bad link?'\n\nWhat would you like to know?";
        }

       
        // SAFE BROWSING RESPONSES
      
        private string GetBrowsingResponse(string msg, string name)
        {
            // What is safe browsing?
            if (msg.Contains("what is") || msg.Contains("define"))
            {
                return $"Great question {name}! \n\nSAFE BROWSING means protecting yourself while using the internet. It's about knowing which websites are trustworthy and keeping your personal information private. Think of it like crossing a road - you look both ways first!\n\nWant to learn HOW to browse safely?";
            }

            // Why is safe browsing important?
            if (msg.Contains("why") || msg.Contains("important"))
            {
                return $"Super important question {name}! \n\nSafe browsing matters because:\n Protects your passwords from being stolen\n Prevents viruses from infecting your computer\n Saves your money from fake shopping sites\n Protects your identity from being stolen\n\nIn South Africa, people lose millions to online scams. Safe browsing stops that! Want to learn HOW?";
            }

            // How to check if a website is safe?
            if (msg.Contains("check") || msg.Contains("safe") || msg.Contains("verify"))
            {
                return $"Let me teach you the website safety check {name}! \n\nSAFETY CHECKLIST:\n Look for the PADLOCK  in the address bar - means secure\n Check for 'https://' not 'http://' - the 's' means secure\n Read the URL carefully - amaz0n.com is FAKE\n Does it look professional? No spelling errors? Contact info?\n Google the website name + 'scam' or 'reviews'\n\nYou're getting so good at this! ";
            }

            // What browser settings to use?
            if (msg.Contains("setting") || msg.Contains("browser"))
            {
                return $"Great question {name}! Let's set up your browser:\n\n SAFE BROWSER SETTINGS:\n1️⃣ Enable 'Safe Browsing' - Chrome: Settings → Privacy → Safe Browsing\n2️⃣ Block pop-ups - most browsers do this automatically\n3️⃣ Don't save passwords in browser - use a password manager instead\n4️⃣ Clear cookies regularly - Settings → Privacy → Clear data\n5️⃣ Keep your browser UPDATED - updates fix security holes\n\nTakes 5 minutes, keeps you safe forever! ";
            }

            // What to avoid while browsing?
            if (msg.Contains("avoid") || msg.Contains("dont") || msg.Contains("dangerous"))
            {
                return $"Smart to ask what to avoid {name}! \n\n Don't click pop-up ads - 'You won an iPhone!' is ALWAYS a scam\n Don't download from untrusted sites - only official websites\n Don't enter personal info on unsecured sites - no padlock? No info!\n Don't ignore security warnings - they appear for a reason\n Don't use public WiFi without protection - hackers can steal your info\n\nSee? Easy to avoid once you know! ";
            }

            // Default browsing response
            return $"I'd love to teach you about safe browsing {name}! \n\nYou can ask me:\n• 'What is safe browsing?'\n• 'Why is safe browsing important?'\n• 'How to check if a website is safe?'\n• 'What browser settings should I use?'\n• 'What to avoid while browsing?'\n\nWhat would you like to know?";
        }

       
        // REPORTING RESPONSES
        
        private string GetReportingResponse(string msg, string name)
        {
            // Where to report phishing emails?
            if (msg.Contains("where") || (msg.Contains("report") && msg.Contains("phish")))
            {
                return $"You're doing the right thing {name}! \n\nWHERE TO REPORT IN SOUTH AFRICA:\n Government: Forward to report@cybersecurity.gov.za\n Your Bank - call fraud department immediately\n📞 SABRIC (banking scams): 0861 022 339\n\nKeep the email as evidence! Thanks for helping stop scammers! ";
            }

            // How to report to SAPS/police?
            if (msg.Contains("saps") || msg.Contains("police") || msg.Contains("crime"))
            {
                return $"Reporting to SAPS is important {name}! \n\n Crime Stop: 0860 010 111 (24/7, anonymous if you want)\n Visit your local police station, ask for Cybercrime Unit\n Bring ALL evidence: emails, screenshots, bank statements\n\nThey'll give you a case number. Don't be scared - the police are there to help! ";
            }

            // What to do after being scammed?
            if (msg.Contains("after") || msg.Contains("scammed") || msg.Contains("victim") || msg.Contains("what to do"))
            {
                return $"I'm sorry if this happened to you {name}. \n\n WHAT TO DO IF SCAMMED:\n1️⃣ DON'T PANIC - stay calm\n2️⃣ CHANGE all your passwords immediately\n3️⃣ CALL YOUR BANK - freeze accounts, report fraud\n4️⃣ REPORT TO SAPS - get a case number\n5️⃣ RUN ANTIVIRUS scan\n6️⃣ MONITOR your credit reports\n\nYou're not alone! Acting fast is what matters. You've got this! ";
            }

            // Why is reporting important?
            if (msg.Contains("why") && msg.Contains("report"))
            {
                return $"Great question {name}! \n\nReporting is IMPORTANT because:\n You HELP OTHERS - authorities can block scammers\n You GET A CASE NUMBER - needed for insurance claims\n🛡️ You HELP CATCH criminals - more reports = more police action\n🛡️ You PROTECT YOURSELF - creates a record of what happened\n\nBy reporting, you're not just helping yourself - you're helping everyone! ";
            }

            // Default reporting response
            return $"I'd love to teach you about reporting {name}! \n\nYou can ask me:\n• 'Where to report phishing emails?'\n• 'How to report to SAPS?'\n• 'What to do after being scammed?'\n• 'Why is reporting important?'\n\nWhat would you like to know?";
        }


        // CYBERSECURITY RESPONSES
       
        private string GetCyberResponse(string msg, string name)
        {
            // What is cybersecurity?
            if (msg.Contains("what is") || msg.Contains("define") || msg.Contains("meaning"))
            {
                return $"Great question {name}! \n\nCYBERSECURITY is protecting yourself, your devices, and your information from online threats. It's like having:\n• A lock on your digital door (passwords)\n• A security guard (antivirus)\n• Training to spot danger (awareness)\n\nIt covers passwords, spotting fake emails, avoiding viruses, and safe browsing.\n\nWant to learn WHY it's so important?";
            }

            // Why is cybersecurity important?
            if (msg.Contains("why") || msg.Contains("important") || msg.Contains("matter"))
            {
                return $"This is so important {name}! \n\nWHY CYBERSECURITY MATTERS:\nIn South Africa, cyber attacks increased 200% recently!\n\nCybersecurity protects:\n YOUR MONEY - bank accounts, cards\n YOUR IDENTITY - personal information\n YOUR PRIVACY - photos, messages\n YOUR DEVICES - computer, phone\n\nBy learning this, you're already safer than most people! ";
            }

            // What are common cyber threats?
            if (msg.Contains("common") || msg.Contains("threats") || msg.Contains("types") || msg.Contains("danger"))
            {
                return $"Let me show you what to watch for {name}! \n\nCOMMON CYBER THREATS:\n PHISHING - Fake emails that steal info\n MALWARE - Viruses on your computer\n RANSOMWARE - Hackers lock your files\n IDENTITY THEFT - Stealing your personal info\n SOCIAL ENGINEERING - Tricking you\n\nNow you know what to watch for! ";
            }

            // How to stay protected?
            if (msg.Contains("stay") || msg.Contains("protect") || msg.Contains("safe") || msg.Contains("habits"))
            {
                return $"Ready to be a cybersecurity superhero {name}? \n\n DAILY SAFETY HABITS:\n1️⃣ Use STRONG, UNIQUE passwords everywhere\n2️⃣ Turn on TWO-FACTOR AUTHENTICATION (2FA)\n3️⃣ Keep EVERYTHING UPDATED - updates fix security holes\n4️⃣ THINK before you click - suspicious? Don't click!\n5️⃣ BACK UP important files\n6️⃣ SHARE what you learn with family and friends\n\nYou're not just protecting yourself - you can protect others too! ";
            }

            // History of cybersecurity
            if (msg.Contains("history") || msg.Contains("started") || msg.Contains("first"))
            {
                return $"Cool question {name}! \n\nCybersecurity started with the first computer viruses in the 1970s!\n\nKey moments:\n• 1971: First computer virus (just a harmless prank)\n• 1988: First major internet attack infected thousands\n• 1990s: Internet became public, cybercrime grew\n• Today: Almost everyone is online, so cybersecurity is CRITICAL\n\nThe good news? You're learning to protect yourself!\n\nWant to learn HOW to stay safe?";
            }

            // Cybersecurity jobs/career
            if (msg.Contains("job") || msg.Contains("career") || msg.Contains("work"))
            {
                return $"Great question {name}! \n\nCybersecurity is a GROWING career!\n\nJobs include:\n• Security Analyst - watches for attacks\n• Ethical Hacker - tests systems by trying to break in\n• Incident Responder - handles attacks when they happen\n\nWhy it's great:\n• High demand (not enough workers!)\n• Good salary\n• You help protect people\n\nIn South Africa, cybersecurity jobs are growing fast!\n\nWant to learn about PROTECTING yourself first?";
            }

            // Default cybersecurity response
            return $"I'd love to teach you about cybersecurity {name}! \n\nYou can ask me:\n• 'What is cybersecurity?'\n• 'Why is cybersecurity important?'\n• 'What are common cyber threats?'\n• 'How to stay protected?'\n• 'History of cybersecurity?'\n• 'Cybersecurity jobs?'\n\nWhat would you like to know?";
        }
    }
}