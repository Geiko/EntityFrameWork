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
    public partial class AllBrands : Form
    {
        CarContext db;
        Form1 form1;
        public AllBrands ( Form1 form1 )
        {
            InitializeComponent ( );
            this.form1 = form1;

            db = new CarContext ( );
            db.Brands.Load ( );
            dataGridView1.DataSource = db.Brands.Local.ToBindingList ( );
        }



        private void button1_Click ( object sender, EventArgs e )
        {
            BrandForm brandForm = new BrandForm ( );
            DialogResult result = brandForm.ShowDialog ( this );
            if ( result == DialogResult.Cancel || brandForm.textBox1.Text == "" && result == DialogResult.OK )
            {
                return;
            }
            Brand newBrand = new Brand ( );
            newBrand.Name = brandForm.textBox1.Text;
            newBrand.Country = brandForm.textBox2.Text;
            db.Brands.Add ( newBrand );
            db.SaveChanges ( );
            
            this.form1.comboBoxForm1.DataSource = db.Brands.ToList ( );
            MessageBox.Show ( "New Brand has been changed." );
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
            Brand brand = db.Brands.Find ( id );
            BrandForm brandForm = new BrandForm ( );
            brandForm.textBox1.Text = brand.Name;
            brandForm.textBox2.Text = brand.Country;
            DialogResult res = brandForm.ShowDialog ( );
            if ( res == DialogResult.Cancel || res == DialogResult.OK && brandForm.textBox1.Text == "" )
            {
                return;
            }
            brand.Name = brandForm.textBox1.Text.Trim ( );
            brand.Country = brandForm.textBox2.Text.Trim ( );

            db.Entry ( brand ).State = EntityState.Modified;
            db.SaveChanges ( );
            MessageBox.Show ( "Brand has been updated successfully." );
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
            Brand brand = db.Brands.Find ( id );
            db.Brands.Remove ( brand );
            db.SaveChanges ( );
            MessageBox.Show ( "Brand has been deleted successfully." );
        }



        private void button4_Click ( object sender, EventArgs e )
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
            Brand brand = db.Brands.Find ( id );
            listBox1.DataSource = brand.Models;
            listBox1.DisplayMember = "Name";
            listBox1.Update ( );
        }
    }
}
