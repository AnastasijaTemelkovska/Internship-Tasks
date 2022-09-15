using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class AtmUser
    {
        public String cardNumber;
        int pin;
        String firstName;
        String lastName;
        double balance;

        public AtmUser(string cardNumber, int pin, string firstName, string lastName, double balance)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public String getNumber()
        {
            return cardNumber;
        }
        public int getPin()
        {
            return pin;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }
        public String getFirstName()
        {
            return firstName;
        }
        public String getLastName()
        {
            return lastName;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setNum(String newCardNum)
        {
            cardNumber = newCardNum;
        }
        public void setFirstName(String newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(String newLastName)
        {
            lastName = newLastName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            void Options()
            {
                Console.WriteLine("What would you like to do:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Cash Withdrawal");
                Console.WriteLine("3. Cash Deposit");
                Console.WriteLine("4. Exit");
            }

            //deposit cash 
            void deposit(AtmUser user)
            {
                Console.WriteLine("How much $$ would you like to deposit? ");
                double deposit = Double.Parse(Console.ReadLine());
                user.setBalance(user.getBalance() + deposit);
                Console.WriteLine("Your balance now is:  " + user.getBalance());

            }
            //withdraw of cash
            void withdrawal(AtmUser user)
            {
                Console.WriteLine("How much $$ would you like to withdraw? ");
                double withdrawal = Double.Parse(Console.ReadLine());
                //Check if the user has enough money
                if (user.getBalance() < withdrawal)
                {
                    Console.WriteLine("");
                }
                else
                {
                    user.setBalance(user.getBalance() - withdrawal);
                    Console.WriteLine("You withdrew: " + withdrawal + ". You have " + user.getBalance() + " left on your account.");
                }

            }
            //current balance of money on their account
            void balance(AtmUser user)
            {
                Console.WriteLine("Current balance: " + user.getBalance());
            }

            List<AtmUser> AtmUsers = new List<AtmUser>();
            AtmUsers.Add(new AtmUser("5467-8908-4353-2632", 2580, "Marija ", "Pejkovska", 260.90));
            AtmUsers.Add(new AtmUser("9023-5434-8913-1538", 1234, "Anita ", "Stojanovska", 130.62));
            AtmUsers.Add(new AtmUser("3459-1036-8436-3841", 3591, "Marko ", "Petkovski", 60.70));
            AtmUsers.Add(new AtmUser("4392-5467-1923-5270", 9392, "Andrej ", "Trajkovski", 350.10));
            AtmUsers.Add(new AtmUser("3291-0432-6784-9361", 1876, "Matea ", "Nikolovska", 190.20));

            //Register a new user
            void register()
            {
                Console.WriteLine("Enter your card number");
                String cardNumNew = Console.ReadLine();
                Console.WriteLine("Enter your pin");
                int newPin = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your name");
                String newName = Console.ReadLine();
                newName += " ";
                Console.WriteLine("Enter your last name");
                String newLastName = Console.ReadLine();
                Console.WriteLine("Enter your balance");
                double newBalance = double.Parse(Console.ReadLine());


                AtmUsers.Add(new AtmUser(cardNumNew, newPin, newName, newLastName, newBalance));
                Console.WriteLine("Your registration was successful!");
                AtmApp();
            }

            // Login user 
            void AtmApp()
            {

                Console.WriteLine("Please enter your card number: ");
                String debitCardNumber = "";
                AtmUser user;

                while (true)
                {
                    try
                    {
                        debitCardNumber = Console.ReadLine();
                        //searching through the customers if a card like that exists
                        user = AtmUsers.FirstOrDefault(c => c.cardNumber == debitCardNumber);
                        if (user != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The card number does not exist.");
                            Console.WriteLine("If you want to register type 1 or if you want to try again type 2.");
                            int option1 = 0;
                            try
                            {
                                option1 = int.Parse(Console.ReadLine());
                            }
                            catch { }
                            if (option1 == 1) { register(); }
                            else if (option1 == 2) { AtmApp(); }
                            else { option1 = 0; }

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please try again");
                    }
                }

                Console.WriteLine("Please enter your pin: ");
                int userPin = 0;

                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                        if (user.getPin() == userPin)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect pin. Please try again");
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Incorrect pin.Please try again");
                    }
                }

                Console.WriteLine("Welcome " + user.getFirstName() + user.getLastName());
                int option = 0;

                do
                {
                    Options();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (option == 1) { balance(user); }
                    if (option == 2) { withdrawal(user); }
                    if (option == 3) { deposit(user); }
                    else if (option == 4)
                    {
                        Console.WriteLine("Thank you for using the ATM app.");
                        WelcomeApp(); //show up the login menu again
                    }
                    else { option = 0; }
                }
                while (option != 4);


            }
            //Main app
            void WelcomeApp()
            {
                Console.WriteLine("Welcome to the ATM app");
                Console.WriteLine("If you want to register type 1 or if you want to log in type 2.");
                int option1 = 0;
                try
                {
                    option1 = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option1 == 1) { register(); }
                else if (option1 == 2) { AtmApp(); }
                else { option1 = 0; }
            }


            WelcomeApp();





        }
    }
}
