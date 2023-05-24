using System.Collections.Generic;
using System.Globalization;
using VechileMS.Models;
using VechileMS.Models.Entities;

namespace VechileMS.Utils
{
    public static class Extensions
    {
        public static void GetInfo(this Vehicle vehicle)
        {
            Console.WriteLine("Enter vehicle details:");

            vehicle.Brand = GetBrand();

            Console.Write("Model: ");
            vehicle.Model = Console.ReadLine();

            Console.Write("Type: ");
            GetType(vehicle);

            Console.Write("Transmission Type: ");
            GetTransmissionType(vehicle);

            Console.Write("Color: ");
            vehicle.Color =  GetColour();

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
            string date = Console.ReadLine();
            try
            {
                vehicle.SellingMonthAndYear = DateTime.ParseExact(
                    date,
                    "d/M/yyyy",
                    CultureInfo.InvariantCulture
                );
            }
            catch (System.FormatException ex)
            {
                vehicle.SellingMonthAndYear = DateTime.ParseExact(
                    date,
                    "d-M-yyyy",
                    CultureInfo.InvariantCulture
                );
            }

            Console.Write("Number: ");
            vehicle.Number = Console.ReadLine();

            Console.Write("Owner Details: ");
            vehicle.OwnerDetails = Console.ReadLine();

            Console.Write("Servicing History: ");
            vehicle.ServicingHistory = Console.ReadLine();

            Console.Write("Is Accidental: ");
            vehicle.IsAccidental = GetTrueFalse();

            Console.Write("Is In Servicing: ");
            vehicle.IsInServicing = GetTrueFalse();

            Console.Write("Any Notes: ");
            vehicle.AddNote(Console.ReadLine());
        }
        public static string GetBrand()
        {
            Console.Write("Select the Brand\n");
            int count = 0;
            foreach (var brand in BrandDictionary.brandDictionary)
            {
                Console.Write($"{brand.Key}. {(brand.Value).ToUpper()}  ");
                count++;
                if (count == 5)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            Console.WriteLine();

            int userInput = int.Parse(Console.ReadLine());
            if (BrandDictionary.brandDictionary.ContainsKey(userInput))
            {
                return BrandDictionary.brandDictionary[userInput];
            }
            else
            {
                return "No - Idea";
            }
        }
        public static bool GetTrueFalse()
        {
            Console.WriteLine("1. True 2. False");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    return true;
                case 2:
                    return false;
                default:
                    return false;
            }
        }
        public static string GetType(this Vehicle vehicle)
        {
            Console.WriteLine("1. Petrol 2. Diesel 3. Electric 4. Hybrid");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    vehicle.Type = "Petrol";
                    break;
                case 2:
                    vehicle.Type = "Diesel";
                    break;
                case 3:
                    vehicle.Type = "Electric";
                    break;
                case 4:
                    vehicle.Type = "Hybrid";
                    break;
                default:
                    vehicle.Type = "No - Idea";
                    break;
            }

            return vehicle.Type;
        }
        public static string GetTransmissionType(this Vehicle vehicle)
        {
            Console.WriteLine("1. Manual 2. Automatic");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    vehicle.TransmissionType = "Manual";
                    break;
                case 2:
                    vehicle.TransmissionType = "Automatic";
                    break;
                default:
                    vehicle.TransmissionType = "No - Idea";
                    break;
            }

            return vehicle.TransmissionType;
        }
        public static string GetColour()
        {
            string Color;
            Console.WriteLine("1. RED 2. BLUE 3. GREEN 4. YELLOW 5. BLACK 6. WHITE \n7. SILVER 8. GREY 9. BROWN 10. ORANGE 11. PURPLE 12. PINK");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Color = "RED";
                    break;
                case 2:
                    Color = "BLUE";
                    break;
                case 3:
                    Color = "GREEN";
                    break;
                case 4:
                    Color = "YELLOW";
                    break;
                case 5:
                    Color = "BLACK";
                    break;
                case 6:
                    Color = "WHITE";
                    break;
                case 7:
                    Color = "SILVER";
                    break;
                case 8:
                    Color = "GREY";
                    break;
                case 9:
                    Color = "BROWN";
                    break;
                case 10:
                    Color = "ORANGE";
                    break;
                case 11:
                    Color = "PURPLE";
                    break;
                case 12:
                    Color = "PINK";
                    break;
                default:
                    Color = "No - Idea";
                    break;
            }

            return Color;

        }
    }
}
