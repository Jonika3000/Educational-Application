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
    public partial class DeleteGroup : Form
    {
        public DeleteGroup()
        {
            InitializeComponent();
            ListLoad();
        }
        private void ListLoad()
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            foreach(var item in form3collection.groups)
            {
                listBox1.Items.Add(item.NameOfGroup);
            }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selected = listBox1.SelectedItem.ToString();
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            foreach(var item in form3collection.studentUsers)
            {
                if(selected == item.Group)
                {
                    item.InGroup = false;
                    item.Group = string.Empty;
                }
            }
            form3collection.groups.Remove(form3collection.groups.Where(gr => gr.NameOfGroup == selected).FirstOrDefault());
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
