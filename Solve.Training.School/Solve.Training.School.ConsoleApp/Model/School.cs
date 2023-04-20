using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.School.ConsoleApp.Model
{
    public abstract class School
    {
        private string name { get; set; }
        private string address { get; set; }
        private string board { get; set; }
        private int noOfStudents { get; set; }

        School(string name, string address, string board, int noOfStudents)
        {
            this.name = name;
            this.address = address;
            this.board = board;
            this.noOfStudents = noOfStudents;
        }

        public virtual void display()
        {
            Console.WriteLine($"Name = {name}, Address = {address}, Board = {board}, NoOfStudents = {noOfStudents} ");
        }
    }
}
