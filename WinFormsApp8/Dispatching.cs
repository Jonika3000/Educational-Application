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
        }

        private void button2_Click(object sender, EventArgs e )
        {
            this.Hide();
            Profile m = new Profile(r, this);
            m.ShowDialog();
        }
    }
}
