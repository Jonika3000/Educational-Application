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
        public Student()
        {
            InitializeComponent();
             

        }
        public Student(User s)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("studentFon.jpg");

        }
    }
}
