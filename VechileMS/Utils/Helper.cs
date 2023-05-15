using VechileMS.Models;
using VechileMS.Models.Entities;

namespace VechileMS.Utils
{
    public class Helper
    {
        public static int GetMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Display Vehicle");
                Console.WriteLine("3. Search Vehicle");
                Console.WriteLine("4. Update Vehicle");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ee)
                {
                    Console.WriteLine("Only number allowed!!!! ");
                    Console.WriteLine("Please Enter your choice again: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
            } while (choice <= 0 || choice > 6);
            return 1;
        }

        public static List<Vehicle> AddVechile(List<Vehicle> list)
        {
            Console.WriteLine("Enter the Vechile Type");
            //switch (Console.ReadLine())
            switch ("Car")
            {
                case "Car":
                    Vehicle car = new Car();
                    //car.GetInfo();

                    Console.Write("Any Notes: ");
                    car.AddNote(Console.ReadLine());
                    list.Add(car);




                    Console.WriteLine(car.ToString());
                    break;
                case "Truck":

                    break;
                default:
                    Console.WriteLine("Supported Vechile Type (Car) : ");
                    break;
            }
            return list;

        }

        public static void RemoveVechile()
        {

        }

        public static void SearchVechile()
        {

        }

        internal static void DisplayVechile()
        {
            throw new NotImplementedException();
        }

        internal static void Exit()
        {
            throw new NotImplementedException();
        }
    }
}