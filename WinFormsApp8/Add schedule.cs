using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp8
{
    public partial class Add_schedule : Form
    {
        User r = new User();
        public Add_schedule()
        {
            InitializeComponent();
        }
        public Add_schedule(User q)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("DispatchingFon.jpeg");
            r = q;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (null != form3collection)
            {
                if (textBox1.Text == null || maskedTextBox2.Text == null || maskedTextBox1.Text == null || textBox4.Text == null)
                {
                    MessageBox.Show( "Error", "Some line is empty" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
                else
                {
                    if(form3collection.users.Any(b => b.Name == textBox4.Text))
                    {

                    }
                    

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
