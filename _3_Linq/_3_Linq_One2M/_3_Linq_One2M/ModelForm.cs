using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Linq_One2M
{
    public partial class ModelForm : Form
    {
        public ModelForm ( )
        {
            InitializeComponent ( );

            numericUpDown1.Maximum = 2000000;
            numericUpDown1.Minimum = 3000;
            numericUpDown1.Value = 20000;
        }
    }
}
