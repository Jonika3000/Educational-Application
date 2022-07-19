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
    public partial class Marks : Form
    {
        public Marks()
        {
            InitializeComponent();
        }
        public Marks(StudentUser r)
        {
            InitializeComponent();
            foreach(var c in r.marks)
            {
                foreach (var b in c.Key.schedule)
                {
                    listBox1.Items.Add($"{b.Key}-{b.Value.Name} -> {c.Value}");
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }
    }
}
