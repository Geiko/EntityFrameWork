using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CarsOneToMany
{
    public class CarContext: DbContext
    {
        public CarContext ( )
            : base("DbConnection")
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
