using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!...");
            Console.WriteLine("Enter the Name: ");
            string name = Console.ReadLine();
            Console.Write("Welcome  " + name);

            cal_start();

            Console.ReadKey();

            /*
             By convention, a return value of 0 is used to indicate a successful program execution. 
            However, it is not necessary to include a return 0; statement in C# because the compiler 
            will automatically generate a return statement at the end of the Main method with a 
            value of 0 if you don't provide one.
             */
        }


        public static void cal_start()
        { 
            Calculator cal = new Calculator();

            int choice;
            do
            {
                Console.WriteLine("\n*****MENU*****");
                Console.WriteLine("1. Additon ");
                Console.WriteLine("2. Subtraction ");
                Console.WriteLine("3. Multiplication ");
                Console.WriteLine("4. Division ");
                Console.WriteLine("99. Exit ");
                Console.WriteLine("****************");
                Console.Write("Task : ");
                choice = (int.Parse(Console.ReadLine()));
                Console.Write(choice + "\n");
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Addition ");
                        Console.WriteLine("= " + cal.add());
                        break;
                    case 2:
                        Console.WriteLine("Subtraction ");
                        Console.WriteLine("= " + cal.sub());
                        break;
                    case 3:
                        Console.WriteLine("Multiplication ");
                        Console.WriteLine("= " + cal.mul());
                        break;
                    case 4:
                        Console.WriteLine("Division ");
                        Console.WriteLine("= " + cal.div());
                        break;
                    case 99:
                        Console.WriteLine("Thank You !! ");
                        break;
                    default:
                        Console.WriteLine("Not Working!!");
                        break;
                }
            } while (choice != 99);
        }
    }


    class Calculator
    {
        public static List<int> input()
        {
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
                    Console.WriteLine("Enter valid Integer");
            }
            foreach(int i in numbers){
                Console.Write(i + " ");
            }
            return numbers;
        }
        public int add()
        { 
            return add(Calculator.input().ToArray());
        }
        public int add(int num)
        {
            return ++num;
        }
        public int add(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
                sum += num;
            //return number.Sum();   // Linq is used
            return sum;
        }
        public int sub()
        {
            Console.Write("Enter Number 1: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write(num1 + " " + num2);
            return sub(num1, num2);
        }
        public int sub(int num1, int num2)
        {
            return  Math.Abs(num1 - num2);
        }
        public int mul()
        {
            return mul(Calculator.input().ToArray());
        }
        public int mul(params int[] numbers)
        {
            int mul = 1;
            foreach (int num in numbers)
                mul *= num;
            return mul;
        }
        public int div()
        {
            Console.Write("Try to give num1 greater\nEnter Two Number 1: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write(num1 + " " + num2);
            return div(num1, num2);
        }
        public int div(int num1, int num2)
        { 
            return (num1 == 0 || num2 == 0) ? -11 : Math.Abs(num1 / num2);
        }
    }

}
