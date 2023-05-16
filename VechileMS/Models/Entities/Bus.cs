using VechileMS.Models;
using VechileMS.Utils;

namespace VechileMS.Models.Entities
{
    public class Bus : DealerVehicle
    {
        public Bus(string name, string brand, string type, string transmissionType,
            string color, int launchYear, double price, float discount
            ) : base("Bus", name, brand, type, transmissionType, color, launchYear, price, discount)
        {

        }

        public Bus() : base("Bus")
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
