using System;
namespace Random_trials.DataTypes
{
    internal class RangeOfTypesBase
    {
        public static void RangeOfTypes()
        {
            Console.WriteLine("Range of all the integral Types");

            Console.WriteLine($"Interger Max Min Length {int.MaxValue} - {int.MinValue}");
            Console.WriteLine($"Byte Max Min Length {byte.MaxValue} - {byte.MinValue}");
            Console.WriteLine($"Short Max Min Length {short.MaxValue} - {short.MinValue}");
            Console.WriteLine($"Long Max Min Length {long.MaxValue} - {long.MinValue}");
            Console.WriteLine("Range of all unsigned integral Types");

            Console.WriteLine($"Uint16 Max Min Length {UInt16.MaxValue} - {UInt16.MinValue}");
            Console.WriteLine($"Uint32 Max Min Length {UInt32.MaxValue} - {UInt32.MinValue}");
            Console.WriteLine($"Uint64 Max Min Length {UInt64.MaxValue} - {UInt64.MinValue}");

        }
    }
}