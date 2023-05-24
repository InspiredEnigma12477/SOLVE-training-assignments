using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileMS.Models
{
    public class CarSeller
    {
        private List<DealerVehicle> vehicles;

        public CarSeller()
        {
            this.vehicles = new List<DealerVehicle>();
        }
        public CarSeller(List<DealerVehicle> list)
        {
            this.vehicles = list;
        }

        public void AddVehicle(DealerVehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }

        public DealerVehicle GetVehicleByNumber(string number)
        {
            return this.vehicles.FirstOrDefault(v => v.Number == number);
        }

        public List<DealerVehicle> GetVehiclesByMade(string brand)
        {
            return this.vehicles.Where(v => v.Brand == brand).ToList();
        }

        public List<DealerVehicle> GetVehiclesByBrand(string brand)
        {
            return this.vehicles.Where(v => v.Brand == brand).ToList();
        }

        public List<DealerVehicle> GetVehiclesByColor(string color)
        {
            return this.vehicles.Where(v => v.Color == color).ToList();
        }

        public List<DealerVehicle> GetVehiclesByAccidentalStatus(bool isAccidental)
        {
            return this.vehicles.Where(v => v.IsAccidental == isAccidental).ToList();
        }

        public List<DealerVehicle> GetVehiclesByTransmissionType(string transmissionType)
        {
            return this.vehicles.Where(v => v.TransmissionType == transmissionType).ToList();
        }
    }
}
