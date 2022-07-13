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
        public Student(User s  )
        {
            InitializeComponent();
           
            this.BackgroundImage = Image.FromFile("studentFon.jpg");
            label2.Text = s.Group;
            label4.Text = s.Name;
            label5.Text = s.Login;
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
    }
}
