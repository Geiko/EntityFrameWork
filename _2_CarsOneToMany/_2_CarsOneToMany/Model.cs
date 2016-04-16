using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CarsOneToMany
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
