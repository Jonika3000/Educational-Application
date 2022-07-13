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
                if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
                {
                    MessageBox.Show("Some line is empty");
                }
                else
                {
                    foreach (var item in form3collection.users)
                    {
                        var parsedDate = DateTime.Parse(textBox2.Text);
                        var parsedDate1 = DateTime.Parse(textBox3.Text);
                        if (textBox4.Text == item.Name && item.Type == "Teacher")
                        {
                            Subject subject = new Subject(textBox1.Text, parsedDate);
                            item.schedule.Add(subject, parsedDate1);
                            MessageBox.Show("Complete!");
                        }
                    }
                }
            }
        }
    }
}
