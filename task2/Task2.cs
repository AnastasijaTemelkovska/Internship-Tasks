using System;
using System.Collections.Generic;
using System.Linq;


namespace Task2
{
    public class User
    {
        int Id;
        String username;
        String password;
        string[] messages = {};

        public User(int Id, string username, string password, string[] messages)
        {
            this.Id = Id;
            this.username = username;
            this.password = password;
            this.messages = messages;
        }

        public int getId()
        {
            return Id;
        }
        public String getUserName()
        {
            return username;
        }
        public String getPassword()
        {
            return password;
        }

        public String[] getMessages()
        {
            return messages;
        }
        public void setId(int newId)
        {
            Id = newId;
        }
        public void setUsername(String newUsername)
        {
            username = newUsername;
        }
        public void setPassword(String newPassword)
        {
            password = newPassword;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] messages = { "Hello!", "How are you?"};
            List<User> Users = new List<User>();
            Users.Add(new User(23, "user1", "password1", messages));
            Users.Add(new User(44, "bokiboki ", "pass2", messages));
            Users.Add(new User(1, "markom", "pass3", messages));

            //Register a new user
            void Register()
            {
                Console.WriteLine("Enter your ID: ");
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your username: ");
                string username1 = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                string password1 = Console.ReadLine();

                bool existing = false;
                foreach (User u in Users)
                {
                    string user1 = u.getUserName();
                    if (user1.Equals(username1))
                    {
                        existing = true;
                        Console.WriteLine("You are alredy registred");

                    }
                }
                if (existing == false)
                {

                    Users.Add(new User(ID, username1, password1, messages));
                    Console.WriteLine("Your registration was successful!");
                    foreach (User us in Users)
                    {
                        int id = us.getId();
                        string user2 = us.getUserName();
                        Console.WriteLine(id + " " + " " + user2);

                    }


                }
                LogIn();

            }

            // Login user 
            void LogIn()
            {
                Console.WriteLine("Please enter your username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                string password = Console.ReadLine();

                bool existing = false;

                foreach(User u in Users)
                {
                    string user = u.getUserName();
                    string pass = u.getPassword();
                    if (user.Equals(username) && pass.Equals(password))
                    {
                        existing = true;
                        Console.WriteLine("Welcome " + user + ". Here are your messages: ");
                        string[] mess = u.getMessages();
                        foreach(string m in mess)
                        {
                            Console.WriteLine(m);
                        }
                    }
                }
                if (existing == false)
                {
                    Console.WriteLine("Wrong username or password. Please try again!");
                    WelcomeApp();
                }
            }

            //Main app
            void WelcomeApp()
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register");
                int option1 = 0;
                try
                {
                    option1 = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option1 == 1) { LogIn(); }
                else if (option1 == 2) { Register(); }
                else { option1 = 0; }
            }

            WelcomeApp();

        }
    }
}

