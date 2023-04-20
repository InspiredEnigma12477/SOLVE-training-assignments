using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.School.ConsoleApp.Model
{
    public abstract class Person
    {
        private int age { get; set; }
        private string name { get; set; }
        private string gender { get; set; }
        private string bloodGroup { get; set; }

        Person(string name, int age, string gender, string bloodGroup)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.bloodGroup = bloodGroup;
        }

        public virtual void getAllInfo()
        {
            Console.WriteLine($"Name = {name}, Gender = {gender}, bloodGroup = {bloodGroup} ");
        }
    }
}
