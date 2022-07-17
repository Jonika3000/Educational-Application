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
            monthCalendar1.ShowToday = true;
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MinDate = DateTime.Now;
            monthCalendar1.MaxDate = DateTime.Now.AddDays(30.0);
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
                    if(form3collection.groups.Any(b => b.NameOfGroup == textBox2.Text) && 
                        (form3collection.users.Any(b => b.Name == textBox4.Text && b.Type == "Teacher"))
                         && maskedTextBox1.Text!=null && maskedTextBox2.Text != null)
                    {
                        if (!form3collection.subjects.Any(ba => ba.Name == textBox1.Text))
                        {
                            form3collection.subjects.Add(new Subject (textBox1.Text , Convert.ToDateTime(maskedTextBox1.Text)));
                        }
                        else
                        {
                            
                            DateTime dt = monthCalendar1.SelectionStart;
                            form3collection.groups.Where(ba => ba.NameOfGroup == textBox2.Text).Select(c => {
                            c.schedule.Add((form3collection.subjects.Where(ba => ba.Name == textBox1.Text).FirstOrDefault()), 
                                dt); return c;
                            }).ToList();

                        }
                    }
                    

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
