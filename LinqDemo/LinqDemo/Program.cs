using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = Utils.Populate();

            var now = DateTime.Now;
            var utcNow = DateTime.UtcNow;

            Console.WriteLine($"Local Now: {now}");
            Console.WriteLine($"UTC Now: {utcNow}");

            function1(list);
            function2(list);
            function3(list);
            function4(list);
            function5(list);
            




            Console.ReadKey();

            /*switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("");
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;

            }*/
        }

        public static void function1(List<Employee> list)
        {
            Console.WriteLine("\n\n |||||||||||||||||||| Employee 122 |||||||||||||||||||||||||||||\n");
            Employee employee = list.FirstOrDefault(e => e.Id == 122);

            if(employee == null)
            {
                Console.WriteLine("Doesn't Exist 122");
            }
            else
            {
                Console.WriteLine(employee.ToString());
            }
        }
        public static void function2(List<Employee> list)
        {
            Console.WriteLine("\n\n |||||||||||||||||||| Even Employees |||||||||||||||||||||||||||||\n");
            var result = list.Where(e => e.Id % 2 == 0);

            if (result == null)
            {
                Console.WriteLine("Even id Employee doesn't exist");
            }
            else
            {
                foreach(var emp in result)
                {
                    Console.WriteLine(emp.ToString());
                }
            }
        }
        public static void function3(List<Employee> list)
        {
            Console.WriteLine("\n\n |||||||||||||||||||| Highest Salary Employee |||||||||||||||||||||||||||||\n");
            Employee employee = list.OrderByDescending(e => e.Salary).FirstOrDefault();

            if (employee == null)
            {
                Console.WriteLine("No Employees");
            }
            else
            {
                Console.WriteLine(employee.ToString());
            }
        }
        public static void function4(List<Employee> list)
        {
            Console.WriteLine("\n\n |||||||||||||||||||| Highest Salary Employee in Mumbai |||||||||||||||||||||||||||||\n");
            Employee employee = list.Where(e => e.City == "Bangalore")
                                    .OrderByDescending(e => e.Salary)
                                    .FirstOrDefault();

            if (employee == null)
            {
                Console.WriteLine("No Employees");
            }
            else
            {
                Console.WriteLine(employee.ToString());
            }
        }
        public static void function5(List<Employee> list)
        {
            Console.WriteLine("\n\n |||||||||||||||||||| Highest from each city Employees |||||||||||||||||||||||||||||\n");
            var result = list.GroupBy(e => e.City).Select(g => g.OrderByDescending(e => e.Salary).FirstOrDefault());

            if (result == null)
            {
                Console.WriteLine("Even id Employee doesn't exist");
            }
            else
            {
                foreach (var emp in result)
                {
                    Console.WriteLine(emp.ToString());
                }
            }
        }
    }
}
