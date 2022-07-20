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
            button1.Click += button1_Click;
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
            DateTime tmp = new DateTime();
            DateTime tmp1 = new DateTime();
            DateTime tmp2 = new DateTime();
            try
            {
                tmp = Convert.ToDateTime(maskedTextBox2.Text);
                tmp1 = Convert.ToDateTime(maskedTextBox1.Text);
                tmp2 = new DateTime();
                tmp2 = tmp2.AddHours(10);
            }
            catch
            {
                MessageBox.Show("Error time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (null != form3collection)
            {

                if (textBox1.Text == string.Empty || maskedTextBox2.Text == string.Empty || maskedTextBox1.Text == string.Empty
                    || textBox4.Text == string.Empty)
                {

                    MessageBox.Show("Some line is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (form3collection.groups.Any(b => b.NameOfGroup == textBox2.Text) &&
                        (form3collection.users.Any(b => b.Name == textBox4.Text && b.Type == "Teacher"))
                         && maskedTextBox1.Text != null && maskedTextBox2.Text != null)
                    {
                        if (!form3collection.subjects.Any(ba => ba.Name == textBox1.Text))
                        {
                            form3collection.subjects.Add(new Subject(textBox1.Text, Convert.ToDateTime(maskedTextBox1.Text)));
                        }
                        DateTime dt = monthCalendar1.SelectionStart;
                        DateTime Time = Convert.ToDateTime(maskedTextBox2.Text);
                        dt = dt.AddHours(Time.Hour);
                        dt = dt.AddMinutes(Time.Minute);
                        form3collection.groups.Where(ba => ba.NameOfGroup == textBox2.Text).Select(c =>
                        {
                            c.schedule.Add((form3collection.subjects.Where(ba => ba.Name == textBox1.Text).FirstOrDefault()),
                                dt); return c;
                        }).ToList();
                        form3collection.teacherUsers.Where(ba => ba.user.Name == textBox4.Text).Select(c =>
                        {
                            c.schedule.Add((form3collection.subjects.Where(ba => ba.Name == textBox1.Text).FirstOrDefault()),
                                dt); return c;
                        }).ToList();
                        Application.OpenForms[1].Visible = true;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Visible = true;
            this.Close();
        }
    }
}
