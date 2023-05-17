using Microsoft.EntityFrameworkCore;
using VechileMS.DataAcessLogic;
using VechileMS.Models;
using VechileMS.Models.Entities;

namespace VechileMS.Utils
{
    public class Helper
    {
        public static int GetMenu()
        {
            int choice = 0;
			Console.WriteLine("\n######### Vehicle Management System #########");
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. Display All Vehicle");
            Console.WriteLine("3. Search Vehicle Based on Number");
            Console.WriteLine("4. Update Vehicle");
            Console.WriteLine("99. Exit");
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
            return choice;
        }

        public static void AddVechile(List<Vehicle> list)
        {
            VechileContext _vehicleContext = new VechileContext();

            Console.WriteLine("Enter the Vechile Type");
            //Lower case accept


            switch (Console.ReadLine().ToLower())
            {
                case "car":
                    _vehicleContext.Add(new Car());
                    break;
                case "truck":
                    _vehicleContext.Add(new Truck());
                    break;
                case "bus":
                    _vehicleContext.Add(new Bus());
                    break;
                default:
                    Console.WriteLine("Supported Vechile Type (Car, Bus, Truck) : ");
                    break;
            }
            _vehicleContext.SaveChanges();
        }

        public static void RemoveVechile() { }

        public static void SearchVechile()
        {
            VechileContext _vehicleContext = new VechileContext();
            Console.WriteLine("Enter the Vechile Type");
        }

        public static void DisplayVechile()
        {
            VechileContext _vehicleContext = new VechileContext();
            List<DealerVehicle> list = _vehicleContext.Vehicles.Include(v => v.Notes).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        internal static void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
