using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.School.ConsoleApp.Model
{
    public class GradStudent : Student
    {
        public GradStudent(string name, int age, string gender, string bloodGroup, int studentID, string gradeLevel)
            : base(name, age, gender, bloodGroup, studentID, gradeLevel)
        {
            Console.WriteLine("Inside Grad School Student");
        }

        public override void Attend()
        {
            Console.WriteLine("Attending Grad school classes...");
        }

        public override void DoHomework()
        {
            Console.WriteLine("Doing Grad school homework...");
        }

        public override void getAllInfo()
        {
            base.getAllInfo();
            Console.WriteLine("School: Grad School");
        }
    }

}
