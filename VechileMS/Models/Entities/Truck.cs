using VechileMS.Models;
using VechileMS.Utils;

namespace VechileMS.Models.Entities
{
    public class Bus : DealerVehicle
    {
        public List<string> Notes { get; set; }
        public Bus(string name, string brand, string type, string transmissionType,
            string color, int launchYear, double price, float discount
            ) : base("Bus", name, brand, type, transmissionType, color, launchYear, price, discount)
        {

        }

        public Bus() : base()
        {
            Notes = new List<string>();
            this.GetInfo();
        }

        public override void AddNote(string note)
        {
            Notes.Add(note);
            base.AddNote(note);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}
