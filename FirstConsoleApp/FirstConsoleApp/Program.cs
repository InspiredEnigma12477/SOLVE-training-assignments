using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!!...");
            Console.WriteLine("Enter the Name: ");
            string name = Console.ReadLine();
            Console.Write(name);

            start();

            Console.ReadKey();
            return 0;
            /*
             By convention, a return value of 0 is used to indicate a successful program execution. 
            However, it is not necessary to include a return 0; statement in C# because the compiler 
            will automatically generate a return statement at the end of the Main method with a 
            value of 0 if you don't provide one.
             */
        }


        public static void start()
        {
            Calculator cal = new Calculator();

            Console.WriteLine("***********MENU******************");
            Console.WriteLine("1. Additon ");
            Console.WriteLine("2. Subtraction ");
            Console.WriteLine("3. Multiplication ");
            Console.WriteLine("4. Division ");
            Console.Write("Task : ");
            int choice = Console.Read();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("inside case 1");
                    cal.add();
                    break;
                case 2:
                    cal.sub();
                    break;
                default:
                    Console.WriteLine("Not Working!!");
            }
        }
    }
    
    
    class Calculator
    {
        public int add()
        {
            Console.Write("Inside Plain add() : ");
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("Enter number or ('done' to finish) : ");
                string input = Console.ReadLine();
                if (input == "done")
                    break;
                if (int.TryParse(input, out int number))
                    numbers.Add(number);
                else
                    Console.Write("Enter valid Integer");
            }
            Calculator cal = new Calculator();
            int sum = cal.add(numbers.ToArray());
            return sum;
        }
        public int add(int num)
        {
            return ++num;
        }
        public int add(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
                sum += num;
            //return number.Sum();   // Linq is used
            return sum;
        }
        public int sub()
        {
            int result = 0;
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("Enter number or ('done' to finish) : ");
                string input = Console.ReadLine();
                if (input == "done")
                    break;
                if (int.TryParse(input, out int number))
                    numbers.Add(number);
                else
                    Console.Write("Enter valid Integer");
            }
            Calculator cal = new Calculator();
            int sum = cal.add(numbers.ToArray());
            return result;
        }
    }

}
