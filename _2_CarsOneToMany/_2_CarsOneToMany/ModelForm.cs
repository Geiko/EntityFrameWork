using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_CarsOneToMany
{
    public partial class ModelForm : Form
    {
        public ModelForm ( )
        {
            InitializeComponent ( );

            numericUpDown1.Maximum = 1000000;
            numericUpDown1.Minimum = 3000;
            numericUpDown1.Value = 20000;
        }
    }
}
