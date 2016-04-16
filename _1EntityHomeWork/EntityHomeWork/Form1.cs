using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EntityHomeWork
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent ( );
        }



        private void Form1_Load ( object sender, EventArgs e )
        {
            using ( CarContext db = new CarContext ( ) )
            {
                var cars = db.Cars;
                foreach ( var car in cars )
                {
                    textBox1.Text += car.ToString() + Environment.NewLine;
                    
                    if ( isExist( comboBoxEngineVolume, car.EngineVolume ) == false )
                    {
                        comboBoxEngineVolume.Items.Add ( car.EngineVolume );
                    }
                }

                if ( this.comboBoxEngineVolume.Items.Count != 0 )
                {
                    if ( this.comboBoxEngineVolume.SelectedItem != null )
                    {
                        this.comboBoxEngineVolume.SelectedIndex = 0;
                    }
                }
            }
        }



        private bool isExist ( ComboBox comboBoxEngineVolume, double engineVolume )
        {
            for ( int i = 0; i < comboBoxEngineVolume.Items.Count; i++ )
            {
                try
                {
                    if ( Convert.ToDouble ( comboBoxEngineVolume.Items [ i ] ) == engineVolume )
                    {
                        return true;
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );
                }
            }
            return false;
        }



        private void btnAllCars_Click ( object sender, EventArgs e )
        {
            using ( CarContext db = new CarContext ( ) )
            {
                textBox1.Text = "";
                var cars = db.Cars;
                foreach ( var car in cars )
                {
                    textBox1.Text += car.ToString ( ) + Environment.NewLine;
                }
            }
        }



        private void btnSelectedCars_Click ( object sender, EventArgs e )
        {
            List<SelectedCar> carsSelected = new List<SelectedCar>();

            using ( CarContext db = new CarContext ( ) )
            {
                textBox1.Text = "";
                var cars = db.Cars;
                foreach ( var car in cars )
                {
                    if ( Convert.ToDouble ( comboBoxEngineVolume.SelectedItem ) == car.EngineVolume )
                    {
                        textBox1.Text += car.ToString ( ) + Environment.NewLine;

                        SelectedCar carSel = new SelectedCar { Id = car.Id, Name = car.Name, Model = car.Model, GearType = car.GearType, EngineVolume = car.EngineVolume, ProductionYear = car.ProductionYear };

                        carsSelected.Add ( carSel );
                    }
                }
            }    

            using(CarContext db = new CarContext ( ) )
            {
                //foreach ( var car in carsSelected )
                //{
                //    db.SelectedCars.Add ( car );
                //}
                SelectedCar car = new SelectedCar { Id = 1, Name = "One", Model = "Two", GearType = "type", EngineVolume = 5.0, ProductionYear = 2000 };
                db.SelectedCars.Add ( car );
                db.SaveChanges ( );
            }          
        }
    }
}
