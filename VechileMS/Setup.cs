using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileMS
{
    internal class Setup
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add vehicle");
                Console.WriteLine("2. List vehicles");
                Console.WriteLine("3. Exit");

                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("Enter vehicle details:");

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Made: ");
                    string made = Console.ReadLine();

                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Type: ");
                    string type = Console.ReadLine();

                    Console.Write("Transmission Type: ");
                    string transmissionType = Console.ReadLine();

                    Console.Write("Color: ");
                    string color = Console.ReadLine();

                    Console.Write("Launch Year: ");
                    int launchYear = int.Parse(Console.ReadLine());

                    Console.Write("Selling Month And Year: ");
                    DateTime sellingMonthAndYear = DateTime.Parse(Console.ReadLine());

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Discount: ");
                    float discount = float.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter {brand} vehicle details:");

                    Console.Write("Number: ");
                    string number = Console.ReadLine();

                    Console.Write("Owner Details: ");
                    string ownerDetails = Console.ReadLine();

                    Console.Write("Servicing History: ");
                    string servicingHistory = Console.ReadLine();

                    Console.Write("Is Accidental: ");
                    bool isAccidental = bool.Parse(Console.ReadLine());

                    Console.Write("Is In Servicing: ");
                    bool isInServicing = bool.Parse(Console.ReadLine());

                    Vehicle vehicle = new Vehicle(name, made, brand, type, transmissionType, color, launchYear,
                        sellingMonthAndYear, price, discount, number, ownerDetails, servicingHistory, isAccidental,
                        isInServicing);

                    vehicles.Add(vehicle);

                    Console.WriteLine("Vehicle added successfully!");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Listing all vehicles:");

                    foreach (Vehicle vehicle in vehicles)
                    {
                        Console.WriteLine(vehicle.ToString());
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("Exiting application...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
}
