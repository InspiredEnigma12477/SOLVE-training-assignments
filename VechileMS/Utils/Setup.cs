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



            bool ExitFlag = false;
            do
            {
                switch (Helper.GetMenu())
                {
                    case 1:
                        Helper.AddVechile(list);
                        break;
                    case 2:
                        Helper.DisplayVechile();
                        break;
                    case 3:
                        Helper.Filters();
                        break;
                    case 4:
                        Helper.ModifyServicingStatus();
                        break;
                        case 5:
                        Helper.DeleteVechile();
                        break;
                    case 99:
                        ExitFlag = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (!ExitFlag);

            Console.WriteLine("\n\nThank you for Using VMS");
        }
    }
}

