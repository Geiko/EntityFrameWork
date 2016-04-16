using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHomeWork
{
    class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string GearType { get; set; }
        public double EngineVolume { get; set; }
        public int ProductionYear { get; set; }
        public override string ToString ( )
        {
            return "- " + this.Name.Trim ( ) + " " + this.Model + " " + this.GearType + " " + this.EngineVolume + " liters " + this.ProductionYear + ";";
        }
    }
}
