using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Linq_One2M
{
    class MyContextInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed ( CarContext db )
        {
            Model fabia = new Model { Name = "Fabia", Price = 10000 };
            Model octavia = new Model { Name = "Octavia", Price = 21000 };
            Model yeti = new Model { Name = "Yeti", Price = 27000 };
            db.Models.AddRange ( new List<Model> { fabia, octavia, yeti } );
            Brand shkoda = new Brand { Name = "Shkoda", Country = "Czechia" };
            shkoda.Models.Add ( fabia );
            shkoda.Models.Add ( octavia );
            shkoda.Models.Add ( yeti );
            db.Brands.Add ( shkoda );

            Model astra = new Model { Name = "Astra", Price = 11000 };
            Model omega = new Model { Name = "Omega", Price = 24000 };
            Model zafira = new Model { Name = "Zafira", Price = 26000 };
            db.Models.AddRange ( new List<Model> { astra, omega, zafira } );
            Brand opel = new Brand { Name = "Opel", Country = "Germany" };
            opel.Models.Add ( astra );
            opel.Models.Add ( omega );
            opel.Models.Add ( zafira );
            db.Brands.Add ( opel );

            Model accord = new Model { Name = "Accord", Price = 22000 };
            Model pilot = new Model { Name = "Pilot", Price = 35000 };
            Model jazz = new Model { Name = "Jazz", Price = 17000 };
            db.Models.AddRange ( new List<Model> { accord, pilot, jazz } );
            Brand honda = new Brand { Name = "Honda", Country = "Japan" };
            honda.Models.Add ( accord );
            honda.Models.Add ( pilot );
            honda.Models.Add ( jazz );
            db.Brands.Add ( honda );

            Model fiesta = new Model { Name = "Fiesta", Price = 11000 };
            Model focus = new Model { Name = "Focus", Price = 11000 };
            Model fusion = new Model { Name = "Fusion", Price = 11000 };
            Model gt = new Model { Name = "GT", Price = 400000 };
            db.Models.AddRange ( new List<Model> { fiesta, focus, fusion, gt } );
            Brand ford = new Brand { Name = "Ford", Country = "USA" };
            ford.Models.Add ( fiesta );
            ford.Models.Add ( focus );
            ford.Models.Add ( fusion );
            ford.Models.Add ( gt );
            db.Brands.Add ( ford );
            
            Model california = new Model { Name = "California", Price = 203000 };
            Model berlinetta = new Model { Name = "Berlinetta", Price = 324000 };
            Model laferrari = new Model { Name = "LaFerrari", Price = 1420000 };
            db.Models.AddRange ( new List<Model> { california, berlinetta, laferrari } );
            Brand ferrari = new Brand { Name = "Ferrari", Country = "Italy" };
            ferrari.Models.Add ( california );
            ferrari.Models.Add ( berlinetta );
            ferrari.Models.Add ( laferrari );
            db.Brands.Add ( ferrari );

            db.SaveChanges ( );
        }
    }
}
