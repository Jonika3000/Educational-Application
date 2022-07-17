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
    public partial class Teacher : Form
    {
        public User r = new User();
        public Teacher()
        {
            InitializeComponent();
            Text = "Teacher Menu";
            this.Icon = new Icon("book_ico.ico");

        }
        public void UpdateL()
        {
            pictureBox1.Image = r.icon;
            label1.Text = r.Login;
            //label3.Text = r.Group;
            label5.Text = r.Name;
        }
        public Teacher(User s)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("TeacherFom.jpg");
            label1.Text = s.Login;
            //label3.Text = s.Group;
            label5.Text = s.Name;
            pictureBox1.Image = s.icon;
            r = s;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
