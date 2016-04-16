using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Linq_One2M
{
    public partial class Form1 : Form
    {
        CarContext db;
        public Form1 ( )
        {
            InitializeComponent ( );
            db = new CarContext ( );
        }

        private void Form1_Load ( object sender, EventArgs e )
        {
            db.Models.Load ( );
            dataGridView1.DataSource = db.Models.Local.ToBindingList ( );

            db.Brands.Load ( );
            comboBoxForm1.DataSource = db.Brands.ToList ( );
            comboBoxForm1.ValueMember = "Id";
            comboBoxForm1.DisplayMember = "Name";
        }



        private void button1_Click ( object sender, EventArgs e )
        {
            ModelForm mdForm = new ModelForm ( );
            mdForm.comboBox1.DataSource = db.Brands.ToList ( );
            mdForm.comboBox1.ValueMember = "Id";
            mdForm.comboBox1.DisplayMember = "Name";

            DialogResult result = mdForm.ShowDialog ( );
            if ( result == DialogResult.Cancel || result == DialogResult.OK && mdForm.textBox1.Text == "" )
            {
                return;
            }
            Model newModel = new Model ( );
            newModel.Name = mdForm.textBox1.Text;
            newModel.Price = ( double ) mdForm.numericUpDown1.Value;
            newModel.Brand = mdForm.comboBox1.SelectedItem as Brand;

            db.Models.Add ( newModel );
            db.SaveChanges ( );
            MessageBox.Show ( "New Model has been added." );
        }



        private void button2_Click ( object sender, EventArgs e )
        {
            if ( dataGridView1.SelectedRows.Count == 0 )
            {
                return;
            }
            int index = dataGridView1.SelectedRows [ 0 ].Index;
            int id;
            bool result = int.TryParse ( dataGridView1 [ 0, index ].Value.ToString ( ), out id );
            if ( result == false )
            {
                return;
            }
            Model model = db.Models.Find ( id );
            ModelForm mdForm = new ModelForm ( );
            mdForm.textBox1.Text = model.Name;
            mdForm.numericUpDown1.Value = Convert.ToDecimal ( model.Price );

            mdForm.comboBox1.DataSource = db.Brands.ToList ( );
            mdForm.comboBox1.ValueMember = "Id";
            mdForm.comboBox1.DisplayMember = "Name";
            if ( model.Brand != null )
            {
                mdForm.comboBox1.SelectedValue = model.Brand.Id;
            }
            DialogResult res = mdForm.ShowDialog ( this );
            if ( res == DialogResult.Cancel )
            {
                return;
            }
            model.Name = mdForm.textBox1.Text;
            model.Price = ( int ) mdForm.numericUpDown1.Value;
            model.Brand = mdForm.comboBox1.SelectedItem as Brand;

            db.Entry ( model ).State = EntityState.Modified;
            db.SaveChanges ( );
            dataGridView1.Update ( );
            MessageBox.Show ( "Model has been updated." );
        }



        private void button3_Click ( object sender, EventArgs e )
        {
            if ( dataGridView1.SelectedRows.Count == 0 )
            {
                return;
            }
            int index = dataGridView1.SelectedRows [ 0 ].Index;
            int id;
            bool result = int.TryParse ( dataGridView1 [ 0, index ].Value.ToString ( ), out id );
            if ( result == false )
            {
                return;
            }
            Model model = db.Models.Find ( id );
            db.Models.Remove ( model );
            db.SaveChanges ( );
            MessageBox.Show ( "Model has been deleted." );
        }



        private void button4_Click ( object sender, EventArgs e )
        {
            AllBrands allBrandsForm = new AllBrands ( this );
            allBrandsForm.Show ( );
        }



        private void button5_Click ( object sender, EventArgs e )
        {
            string selectedBrand = comboBoxForm1.SelectedItem.ToString ( );
            //var filteredArray = from model in db.Models
            //                    where model.Brand.Name == selectedBrand
            //                    select model;
            var filteredArray = db.Models.Where ( model => model.Brand.Name == selectedBrand );
            dataGridView1.DataSource = filteredArray.ToList ( );

            var maxPrice = filteredArray.Max ( model => model.Price );
            textBox1.Text = maxPrice.ToString ( );

            var averagePrice = filteredArray.Average ( model => model.Price );
            textBox2.Text = averagePrice.ToString ( );

            var minPrice = filteredArray.Min ( model => model.Price );
            textBox3.Text = minPrice.ToString ( );            
        }



        private void button6_Click ( object sender, EventArgs e )
        {
            dataGridView1.DataSource = db.Models.ToList();
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }
    }
}
