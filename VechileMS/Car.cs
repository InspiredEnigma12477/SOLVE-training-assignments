using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileMS
{
    public class Car : Vehicle
    {
        public override string BrandOverride => "Car";
        public override string Number { get; set; }
        public override string OwnerDetails { get; set; }
        public override string ServicingHistory { get; set; }
        public override bool IsAccidental { get; set; }
    }

}
