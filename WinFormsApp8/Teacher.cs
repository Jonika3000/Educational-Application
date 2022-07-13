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
        public Teacher()
        {
            InitializeComponent();
        }
        public Teacher(User s)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("TeacherFom.jpg");
            label1.Text = s.Login;
            label3.Text = s.Group;
            label5.Text = s.Name;
        }
    }
}
