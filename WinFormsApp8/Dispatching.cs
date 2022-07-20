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
    public partial class Dispatching : Form
    {
     public   User r = new User();
        public Dispatching()
        {
            InitializeComponent();
        }
        public Dispatching(User q)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("DispatchingFon.jpeg");
            r = q;
            label1.Text = r.Login;
            pictureBox1.Image = q.icon;
            Text = "Dispatching Menu";
            this.Icon = new Icon("book_ico.ico");
        }
        public void UpdateL ()
        {
            pictureBox1.Image = r.icon;
            label1.Text=r.Login;
            //label2.Text = r.Group;
            label4.Text = r.Name;
        }
        private void button2_Click(object sender, EventArgs e )
        {
            this.Hide();
            Profile m = new Profile(r, this);
            m.ShowDialog();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_schedule t = new Add_schedule();
            t.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddGroup t = new AddGroup();
            t.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteGroup deleteGroup = new DeleteGroup();
            deleteGroup.ShowDialog();
        }
    }
}
