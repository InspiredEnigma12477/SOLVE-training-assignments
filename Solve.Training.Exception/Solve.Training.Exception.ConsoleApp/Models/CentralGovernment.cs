using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.ExceptionCode.ConsoleApp.Models
{
    class CentralGovernment
    {
        private String Ministries_Name { get; set; }
        public int Budget { get; }
        public int ThresholdAmount { get; }

        public CentralGovernment()
        {
            Console.Write("Central Government : Ministry Name Please:  ");
            this.Ministries_Name = Console.ReadLine();
            this.ThresholdAmount = 2_000_000_000;

        }

        public virtual double FundsDisburment(double funds)
        {
            Console.Write("Central Government Disbursing amount ");
            return funds;
        }
        public virtual double FundsRequested()
        {
            Console.WriteLine("Central Government");
            Console.WriteLine("Enter the funds required: ");
            double funds = double.Parse(Console.ReadLine());
            FundsRequested(funds);
            return funds;
        }
        public virtual double FundsRequested(double funds)
        {
            Console.Write("Central Government Requestring RBI for funds of Rs. " + funds);
            return funds;
        }

    }
}
