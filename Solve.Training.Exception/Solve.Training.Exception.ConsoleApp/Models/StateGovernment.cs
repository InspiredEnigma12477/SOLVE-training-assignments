using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.ExceptionCode.ConsoleApp.Models
{
    class StateGovernment : CentralGovernment
    {

        private String StateName { get; }

        public int StateBudget { get; }
        private double funds_allocated { get; set; }
        private double fund_requested { get; set; }

        public int ThresholdAmount { get; }

        public StateGovernment()
        {
            Console.WriteLine("Government wants to know which State this is ");
            this.StateName = Console.ReadLine();
        }

        public StateGovernment(String StateName)
        {
            this.StateName = StateName;
            Console.Write($"Initalising {this.StateName} Government");

        }
        public override double FundsRequested()
        {
            Console.WriteLine("State Government");
            Console.WriteLine("Enter the funds required: ");
            double funds = double.Parse(Console.ReadLine());
            FundsRequested(funds);
            return funds;
        }
        public override double FundsRequested(double funds)
        {
            Console.WriteLine("Requesting Central Government for funds");

            try
            {
                Console.WriteLine($"Requested Amount {funds}  want to add some more");
                double request = double.Parse(Console.ReadLine());
                this.fund_requested = funds + request;

                if(fund_requested > base.ThresholdAmount && this.StateBudget < fund_requested)
                {
                    Exception exception = new Exception();
                    throw exception;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Caught");
                Console.WriteLine(ex.Message);
                throw ex;
            }
            base.FundsRequested();
            return fund_requested;
        }

        public override double FundsDisburment(double funds)
        {
            this.funds_allocated = funds;
            return funds_allocated;
        }
    }
}
