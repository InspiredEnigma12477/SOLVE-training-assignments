using VechileMS.Models;

namespace VechileMS.Utils
{
    public class Setup
    {
        public Setup()
        {
            Console.WriteLine("#######################################################");
            Console.WriteLine("################# Vechile Management ##################");
            Console.WriteLine("#######################################################");

            //Helper.LoadData();
            List<Vehicle> list = new List<Vehicle>();






            switch (Helper.GetMenu())
            {
                case 1:
                    Helper.AddVechile(list);
                    break;
                case 2:
                    Helper.RemoveVechile();
                    break;
                case 3:
                    Helper.SearchVechile();
                    break;
                case 4:
                    Helper.DisplayVechile();
                    break;
                case 5:
                    Helper.Exit();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine("\n\nThank you for Using VMS");

            Console.ReadKey();
        }
    }
}

