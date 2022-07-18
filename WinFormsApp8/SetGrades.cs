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
    public partial class SetGrades : Form
    {
        
        Group g = new Group();
        public SetGrades()
        {
            InitializeComponent();
            textBox1.TextChanged += FindGroup;
        }
        public void FindGroup(object sender,EventArgs e)
        {
            try
            {
                var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
                g = form3collection.groups.Where(group => group.NameOfGroup == textBox1.Text).FirstOrDefault();
                foreach(var t in form3collection.groups)
                {
                    if (t.NameOfGroup == textBox1.Text)
                    {
                        foreach (var c in t.users)
                            listBox1.Items.Add(c.r.Name);
                        break;
                    }
                }
                //listBox1.DataSource = form3collection.groups.Where(group => group.NameOfGroup == textBox1.Text).Select(g => g.users);
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }
    }
}
