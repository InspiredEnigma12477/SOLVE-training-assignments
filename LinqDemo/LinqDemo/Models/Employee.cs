using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string City { get; set; }
        public double Salary { get; set; }

        public Employee()
        {
            Console.WriteLine("Inside Employee Default");
        }

        public Employee(int id, string name, string city, double salary)
        {
            Id = id;
            Name = name;
            City = city;
            Salary = salary;
        }

        public override string ToString()
        {
            return $" Employee({Id},{Name},{City},{Salary})";
        }
    }
}
