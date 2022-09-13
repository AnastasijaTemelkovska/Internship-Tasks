using System;

namespace Task1
{
    
       
    class Program
    {
        static void NumberStats(string number)
        {
            
            double m = double.Parse(number);
            int n = (int)m;

            Console.WriteLine("Stats for number: " + number);
            //Find out if the number is negative or positive
            if (m == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (m > 0)
                {
                    Console.WriteLine("Positive");
                }
                else
                {
                    Console.WriteLine("Negative");
                }
            }
            //Find out if the number is decimal or integer
            if (n == m)
            {
                Console.WriteLine("Integer");
            }
            else
            {
                Console.WriteLine("Decimal");
            }
            //Find out if the number is odd or even
            if ((m % 2) == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }

            static void Main(string[] args)
        {
         
        //  Console.WriteLine("Input number");
            String number = Console.ReadLine();


            NumberStats(number);
          
            }

           
        
    }
}
