using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.School.ConsoleApp.Model
{
    public abstract class Student : Person, IStudentBehavior
    {
        private int studentID { get; set; }
        private string gradeLevel { get; set; }

        public Student(string name, int age, string gender, string bloodGroup int studentID, string gradeLevel): base(name, age, gender, bloodGroup)
        { 
            this.studentID = studentID;
            this.gradeLevel = gradeLevel;
        }

        public override void getAllInfo()
        {
            base.getAllInfo();   
            Console.WriteLine($"Student ID: {studentID}, Grade Level: {gradeLevel} ");
        }

        public abstract void Attend();

        public abstract void DoHomework();
    }
}
