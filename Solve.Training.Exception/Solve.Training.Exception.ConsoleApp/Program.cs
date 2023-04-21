using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solve.Training.ExceptionCode.ConsoleApp.Models;

namespace Solve.Training.ExceptionCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CentralGovernment cg = new MunicipalCorporation();

            cg.FundsRequested();

            Console.ReadKey();

        }
    }
}
