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

namespace _2_CarsOneToMany
{
    public partial class AllBrands : Form
    {
        CarContext db;
        public AllBrands ( )
        {
            InitializeComponent ( );
            db = new CarContext ( );
            db.Brands.Load ( );
            dataGridView1.DataSource = db.Brands.Local.ToBindingList ( );
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            BrandForm brandForm = new BrandForm ( );
            DialogResult result = brandForm.ShowDialog ( this );
            if ( result == DialogResult.Cancel || brandForm.textBox1.Text.Trim ( ) == "" )
            {
                return;
            }
            Brand newBrand = new Brand ( );
            newBrand.Name = brandForm.textBox1.Text.Trim ( );
            newBrand.Country = brandForm.textBox2.Text.Trim ( );

            db.Brands.Add ( newBrand );
            db.SaveChanges ( );
            Console.WriteLine ("New Brand has been added successsfully.");
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            if(dataGridView1.SelectedRows.Count > 0 )
            {
                int index = dataGridView1.SelectedRows [ 0 ].Index;
                int id;
                bool result = int.TryParse ( dataGridView1 [ 0, index ].Value.ToString ( ), out id );
                if(result == false )
                {
                    return;
                }
                Brand brand = db.Brands.Find ( id );
                BrandForm brandForm = new BrandForm ( );
                brandForm.textBox1.Text = brand.Name;
                brandForm.textBox2.Text = brand.Country;

                DialogResult res = brandForm.ShowDialog ( );
                if(res == DialogResult.Cancel )
                {
                    return;
                }
                brand.Name = brandForm.textBox1.Text.Trim ( );
                brand.Country = brandForm.textBox2.Text.Trim ( );

                db.Entry ( brand ).State = EntityState.Modified;
                db.SaveChanges ( );
                //MessageBox.Show ( "Brand has been updated." );
            }
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            if(dataGridView1.SelectedRows.Count > 0 )
            {
                int index = dataGridView1.SelectedRows [ 0 ].Index;
                int id;
                bool result = int.TryParse ( dataGridView1[0, index].Value.ToString(), out id);
                if(result == false )
                {
                    return;
                }
                Brand brand = db.Brands.Find ( id );
                db.Brands.Remove ( brand );
                db.SaveChanges ( );
                brand.Models.Clear ( );
                MessageBox.Show ( "Brand has been removed." );
            }
        }

        private void button4_Click ( object sender, EventArgs e )
        {
            if ( dataGridView1.SelectedRows.Count > 0 )
            {
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
}
