using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.School.ConsoleApp.Model
{
    class Solve_School
    {
        List<GradStudent> stu;

        public Solve_School()
        {
            List<GradStudent> stu = new List<GradStudent>();
        }

        public void addStu()
        {
            stu.Add(new HighSchoolStudent(""));
        }


    }
}
