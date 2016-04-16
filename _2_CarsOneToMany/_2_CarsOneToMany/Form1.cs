using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace _2_CarsOneToMany
{
    public partial class Form1 : Form
    {
        CarContext db;
        public Form1 ( )
        {
            InitializeComponent ( );
            db = new CarContext ( );
            db.Models.Load ( );
            dataGridView1.DataSource = db.Models.Local.ToBindingList ( );

            dataGridView1.Sort ( dataGridView1.Columns[2], ListSortDirection.Ascending );

            numericUpDown1.Maximum = 1000000;
            numericUpDown1.Minimum = 3000;
            numericUpDown1.Value = 30000;

            numericUpDown2.Maximum = 1000000;
            numericUpDown2.Minimum = 3000;
            numericUpDown2.Value = 20000;
        }



        private void button1_Click ( object sender, EventArgs e )
        {
            ModelForm modelForm = new ModelForm ( );
            modelForm.comboBox1.DataSource = db.Brands.ToList ( );
            modelForm.comboBox1.ValueMember = "Id";
            modelForm.comboBox1.DisplayMember = "Name";

            DialogResult result = modelForm.ShowDialog ( this );
            if(result == DialogResult.Cancel )
            {
                return;
            }
            Model newModel = new Model ( );
            newModel.Brand = modelForm.comboBox1.SelectedItem as Brand;
            newModel.Name = modelForm.textBox1.Text;
            newModel.Price = ( double ) modelForm.numericUpDown1.Value;

            db.Models.Add ( newModel );
            db.SaveChanges ( );
            Console.WriteLine ("New model has been added successfully");
        }



        private void button2_Click ( object sender, EventArgs e )
        {
            if(dataGridView1.SelectedRows.Count > 0 )
            {
                int index = dataGridView1.SelectedRows [ 0 ].Index;
                int id = 0;
                bool converted = Int32.TryParse ( dataGridView1 [ 0, index ].Value.ToString ( ), out id );
                if ( converted == false )
                {
                    return;
                }

                Model model = db.Models.Find ( id );
                ModelForm modelForm = new ModelForm ( );

                modelForm.textBox1.Text = model.Name;
                modelForm.numericUpDown1.Value = Convert.ToDecimal ( model.Price ) ;
                
                modelForm.comboBox1.DataSource = db.Brands.ToList ( );
                modelForm.comboBox1.ValueMember = "Id";
                modelForm.comboBox1.DisplayMember = "Name";
                if ( model.Brand != null )
                {
                    modelForm.comboBox1.SelectedValue = model.Brand.Id;
                }

                DialogResult result = modelForm.ShowDialog ( this );
                if ( result == DialogResult.Cancel )
                {
                    return;
                }
                model.Name = modelForm.textBox1.Text;
                model.Price = ( double ) modelForm.numericUpDown1.Value;
                model.Brand = modelForm.comboBox1.SelectedItem as Brand;

                db.Entry ( model ).State = EntityState.Modified;
                db.SaveChanges ( );
                dataGridView1.Update ( );
                //MessageBox.Show ( "Model updated!" );
            }
        }



        private void button3_Click ( object sender, EventArgs e )
        {

            if ( dataGridView1.SelectedRows.Count > 0 )
            {
                int index = dataGridView1.SelectedRows [ 0 ].Index;
                int id = 0;
                bool converted = Int32.TryParse ( dataGridView1 [ 0, index ].Value.ToString ( ), out id );
                if ( converted == false )
                {
                    return;
                }

                Model model = db.Models.Find ( id );

                db.Models.Remove ( model );
                db.SaveChanges ( );
                MessageBox.Show ( "Model has been deleted." );

            }
        }



        private void button4_Click ( object sender, EventArgs e )
        {
            AllBrands brands = new AllBrands ( );
            brands.Show ( );
        }



        private void button5_Click ( object sender, EventArgs e )
        {
            dataGridView1.CurrentCell = null;
            for ( int i = 0; i < dataGridView1.Rows.Count; i++ )
            {
                dataGridView1.Rows [ i ].Visible = 
                    (
                    int.Parse( dataGridView1 [ 2, i ].Value.ToString()) < 
                    int.Parse( numericUpDown1.Value.ToString ( ))
                    &&
                    int.Parse ( dataGridView1 [ 2, i ].Value.ToString ( ) ) >
                    int.Parse ( numericUpDown2.Value.ToString ( ))
                    );
            }

        }



        private void button6_Click ( object sender, EventArgs e )
        {
            dataGridView1.CurrentCell = null;
            for ( int i = 0; i < dataGridView1.Rows.Count; i++ )
            {
                dataGridView1.Rows [ i ].Visible = true;
            }
        }
    }
}
