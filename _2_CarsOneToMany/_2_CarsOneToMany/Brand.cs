using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CarsOneToMany
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public Brand ( )
        {
            Models = new List<Model> ( );
        }
        public override string ToString ( )
        {
            return Name;
        }
    }
}
