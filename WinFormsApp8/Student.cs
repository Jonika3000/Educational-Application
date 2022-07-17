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
    public partial class Student : Form
    {
           public User r = new User();
            public Student()
            {
                InitializeComponent();
            }
            public Student(User s  )
        {
            InitializeComponent();
            Text = "Student menu";
            this.Icon = new Icon("book_ico.ico");
            this.BackgroundImage = Image.FromFile("studentFon.jpg");
            pictureBox1.Image = s.icon;
            label2.Text = s.Group;
            label4.Text = s.Name;
            label5.Text = s.Login;
            r = s;
        }
        public void UpdateL()
        {
            pictureBox1.Image = r.icon;
            //label1.Text = r.Login;
            label2.Text = r.Group;
            label4.Text = r.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Marks s = new Marks();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "Login").FirstOrDefault();
            if (null != frm)
            {
                this.Close();
                frm.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile m = new Profile(r, this);
            m.ShowDialog();
        }
    }
}
