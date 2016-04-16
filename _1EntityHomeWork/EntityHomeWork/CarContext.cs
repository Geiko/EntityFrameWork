using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHomeWork
{
    class CarContext : DbContext
    {
        public CarContext(): base ( "DbConnection" )
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<SelectedCar> SelectedCars { get; set; }
    }
}
