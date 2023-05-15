using System.Globalization;
using VechileMS.Models;

namespace VechileMS.Utils
{
    public static class Extensions
    {
        public static void GetInfo(this Vehicle vehicle)
        {
            Console.WriteLine("Enter vehicle details:");

            Console.Write("Model: ");
            vehicle.Model = Console.ReadLine();

            Console.Write("Brand: ");
            vehicle.Brand = Console.ReadLine();

            Console.Write("Type: ");
            vehicle.Type = Console.ReadLine();

            Console.Write("Transmission Type: ");
            vehicle.TransmissionType = Console.ReadLine();

            Console.Write("Color: ");
            vehicle.Color = Console.ReadLine();

            Console.Write("Launch Year: ");
            vehicle.LaunchYear = int.Parse(Console.ReadLine());

            Console.Write("Price: ");
            vehicle.Price = double.Parse(Console.ReadLine());

            Console.Write("Discount: ");
            vehicle.Discount = float.Parse(Console.ReadLine());

        }

        public static void GetDetails(this DealerVehicle vehicle)
        {
            Console.WriteLine($"Enter vehicle details:");

            Console.Write("Selling Month And Year (dd/MM/yyyy) : ");
            vehicle.SellingMonthAndYear = DateTime.ParseExact(Console.ReadLine(), "dd/M/yyyy", CultureInfo.InvariantCulture);
            //DateTime.ParseExact(dateTimeString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Number: ");
            vehicle.Number = Console.ReadLine();

            Console.Write("Owner Details: ");
            vehicle.OwnerDetails = Console.ReadLine();

            Console.Write("Servicing History: ");
            vehicle.ServicingHistory = Console.ReadLine();

            Console.Write("Is Accidental: ");
            vehicle.IsAccidental = bool.Parse(Console.ReadLine());

            Console.Write("Is In Servicing: ");
            vehicle.IsInServicing = bool.Parse(Console.ReadLine());
        }
    }
}