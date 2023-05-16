using VechileMS.Utils;

namespace VechileMS.Models.Entities
{
    public class Car : DealerVehicle
    {
        public Car(string name, string brand, string type, string transmissionType,
            string color, int launchYear, double price, float discount
            ) : base("Car", name, brand, type, transmissionType, color, launchYear, price, discount)
        {
            
        }

        public Car() : base("Car")
        {
            this.GetInfo();
        }

        public override void AddNote(string note)
        {
            base.AddNote(note);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}
