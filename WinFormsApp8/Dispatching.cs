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
        User r = new User();
        public Dispatching()
        {
            InitializeComponent();
        }
        public Dispatching(User r)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("DispatchingFon.jpeg");
            label1.Text = r.Login;
        }

        private void button2_Click(object sender, EventArgs e )
        {
            Profile m = new Profile(r, this);
            m.Show();
        }
    }
}
