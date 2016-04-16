namespace EntityHomeWork
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.comboBoxEngineVolume = new System.Windows.Forms.ComboBox();
            this.btnSelectedCars = new System.Windows.Forms.Button();
            this.btnAllCars = new System.Windows.Forms.Button();
            this.labelForComboBox = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxEngineVolume
            // 
            this.comboBoxEngineVolume.FormattingEnabled = true;
            this.comboBoxEngineVolume.Location = new System.Drawing.Point(151, 193);
            this.comboBoxEngineVolume.Name = "comboBoxEngineVolume";
            this.comboBoxEngineVolume.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEngineVolume.TabIndex = 1;
            // 
            // btnSelectedCars
            // 
            this.btnSelectedCars.Location = new System.Drawing.Point(151, 220);
            this.btnSelectedCars.Name = "btnSelectedCars";
            this.btnSelectedCars.Size = new System.Drawing.Size(121, 29);
            this.btnSelectedCars.TabIndex = 2;
            this.btnSelectedCars.Text = "Show selected cars";
            this.btnSelectedCars.UseVisualStyleBackColor = true;
            this.btnSelectedCars.Click += new System.EventHandler(this.btnSelectedCars_Click);
            // 
            // btnAllCars
            // 
            this.btnAllCars.Location = new System.Drawing.Point(13, 171);
            this.btnAllCars.Name = "btnAllCars";
            this.btnAllCars.Size = new System.Drawing.Size(117, 78);
            this.btnAllCars.TabIndex = 3;
            this.btnAllCars.Text = "Show all cars";
            this.btnAllCars.UseVisualStyleBackColor = true;
            this.btnAllCars.Click += new System.EventHandler(this.btnAllCars_Click);
            // 
            // labelForComboBox
            // 
            this.labelForComboBox.AutoSize = true;
            this.labelForComboBox.Location = new System.Drawing.Point(151, 174);
            this.labelForComboBox.Name = "labelForComboBox";
            this.labelForComboBox.Size = new System.Drawing.Size(109, 13);
            this.labelForComboBox.TabIndex = 4;
            this.labelForComboBox.Text = "Select engine volume";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 143);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelForComboBox);
            this.Controls.Add(this.btnAllCars);
            this.Controls.Add(this.btnSelectedCars);
            this.Controls.Add(this.comboBoxEngineVolume);
            this.Name = "Form1";
            this.Text = "CARS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxEngineVolume;
        private System.Windows.Forms.Button btnSelectedCars;
        private System.Windows.Forms.Button btnAllCars;
        private System.Windows.Forms.Label labelForComboBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

