using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Linq_One2M
{
    public class CarContext: DbContext
    {
        static CarContext ( )
        {
            Database.SetInitializer<CarContext> ( new MyContextInitializer ( ) );
        }



        public CarContext ( )
            : base("DbConnection")
        {
                
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models{ get; set; }
    }
}
