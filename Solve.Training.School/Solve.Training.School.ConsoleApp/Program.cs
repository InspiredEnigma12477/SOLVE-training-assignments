using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solve.Training.School.ConsoleApp.Model;

namespace Solve.Training.School.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve_School sch = new Solve_School(Populate());

            sch.ToString();

            Console.ReadKey();

        }

        public static List<GradStudent> Populate()
        {
            List<GradStudent> gradStudents = new List<GradStudent>();

            gradStudents.Add(new GradStudent("Narendra Modi", 71, "Male", "B+", 1001, "Bharatiya Janata Party"));
            gradStudents.Add(new GradStudent("Rahul Gandhi", 51, "Male", "O+", 1002, "Indian National Congress"));
            gradStudents.Add(new GradStudent("Mamata Banerjee", 67, "Female", "A+", 1003, "All India Trinamool Congress"));
            gradStudents.Add(new GradStudent("Arvind Kejriwal", 53, "Male", "AB+", 1004, "Aam Aadmi Party"));
            gradStudents.Add(new GradStudent("Yogi Adityanath", 48, "Male", "B-", 1005, "Bharatiya Janata Party"));
            gradStudents.Add(new GradStudent("Uddhav Thackeray", 62, "Male", "O-", 1006, "Shiv Sena"));
            gradStudents.Add(new GradStudent("Mayawati", 66, "Female", "A-", 1007, "Bahujan Samaj Party"));
            gradStudents.Add(new GradStudent("Sharad Pawar", 81, "Male", "B+", 1008, "Nationalist Congress Party"));
            gradStudents.Add(new GradStudent("Nitish Kumar", 71, "Male", "AB-", 1009, "Janata Dal (United)"));
            gradStudents.Add(new GradStudent("Akhilesh Yadav", 48, "Male", "O+", 1010, "Samajwadi Party"));
            gradStudents.Add(new GradStudent("Chulbul Pandey", 46, "Male", "O+", 1011, "Dabangg"));
            gradStudents.Add(new GradStudent("Munna Bhai", 52, "Male", "A+", 1012, "Munna Bhai M.B.B.S."));
            gradStudents.Add(new GradStudent("Vijay Deenanath Chauhan", 35, "Male", "AB+", 1013, "Agneepath"));
            gradStudents.Add(new GradStudent("Jasmeet Kaur", 25, "Female", "B+",1014, "Namaste London"));
            gradStudents.Add(new GradStudent("Raj Malhotra", 27, "Male", "O+",1015, "Dilwale Dulhania Le Jayenge"));
            gradStudents.Add(new GradStudent("Geet Dhillon", 28, "Female", "B-",1016, "Jab We Met"));
            gradStudents.Add(new GradStudent("Veer Pratap Singh", 33, "Male", "AB-",1017, "Veer-Zaara"));
            gradStudents.Add(new GradStudent("Sonia Singh", 29, "Female", "O-",1018, "Rang De Basanti"));
            gradStudents.Add(new GradStudent("Simran Singh", 25, "Female", "A-",1019, "DDLJ"));
            gradStudents.Add(new GradStudent("Baburao Ganpatrao Apte", 60, "Male", "O+",1020, "Hera Pheri"));

            return gradStudents;
        }
    }
}
