using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.School.ConsoleApp.Model
{
    class Solve_School : School
    {
        List<GradStudent> stu;

        public Solve_School()
        {
            Console.WriteLine("Default Constructor of Solve School");
        }
        public Solve_School( List<GradStudent> stu)
        {
            this.stu = stu;
        }

        public override void getAllInfo()
        {
            stu.ToString();
        }

        public override string ToString()
        {
            foreach (GradStudent s in stu)
            {
                Console.WriteLine(s.ToString());
            }

            return base.ToString();
        }

    }
}
