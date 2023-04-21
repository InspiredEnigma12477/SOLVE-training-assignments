using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve.Training.ExceptionCode.ConsoleApp.Models
{
    class MunicipalCorporation : StateGovernment
    {
        private String Municipality_Name { get; }
        private double funds_allocated { get; set; }
        private double fund_requested { get; set; }

        public int CorporationBudget { get; }
        public MunicipalCorporation()
        {
            Console.Write("State Government wants to know which Municipal Corporation this is ");
            this.Municipality_Name = Console.ReadLine();
            this.CorporationBudget = 2_000_000;
        }

        public MunicipalCorporation(String Municipality_Name)
        {
            this.Municipality_Name = Municipality_Name;
            Console.WriteLine($"Initalising {this.Municipality_Name} Municipal Corporation");
        }
        public override double FundsRequested()
        {
            Console.WriteLine("Municipal Coorporation");
            Console.WriteLine("Enter the funds required: ");
            double funds = double.Parse(Console.ReadLine());
            FundsRequested(funds);
            return funds;
        }
        public override double FundsRequested(double funds)
        {
            Console.WriteLine("\nRequesting State Government for funds");
            try
            {
                if (base.ThresholdAmount < funds && this.CorporationBudget < funds)
                {
                    Exception exception = new Exception("Muncipal Error : Above Limit");
                    throw exception;
                }
                this.fund_requested = funds;
            }
            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error ");
                Console.WriteLine("Funds are above the limit : ");
                double request = double.Parse(Console.ReadLine());
                this.fund_requested = request;
                Console.ForegroundColor = ConsoleColor.White;
                if (base.ThresholdAmount < fund_requested && this.CorporationBudget < fund_requested)
                {
                    throw ex;
                }

            }
            base.FundsRequested(fund_requested);
            return fund_requested;
        }

        public override double FundsDisburment(double funds)
        {
            this.funds_allocated = funds;
            return funds_allocated;
        }


    }
}
