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
    public partial class AddGroup : Form
    {
        Group g = new Group();
        public AddGroup()
        {
            InitializeComponent();
            AddListBoxStudents();
            AddListBoxTeachers();
        }
        void AddListBoxStudents()
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            var range = form3collection.studentUsers.Where(n => n.r.Name != string.Empty);
            foreach(var student in form3collection.studentUsers)
            {
                listBox1.Items.Add(student.r.Name);
            }
        }
        void AddListBoxTeachers()
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            foreach (var student in form3collection.users)
            {
                if(student.Type == "Teacher")
                listBox2.Items.Add(student.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            string curItem = listBox1.SelectedItem.ToString();
            g.users.Add(form3collection.studentUsers.Where(w => w.r.Name == curItem).FirstOrDefault());
            form3collection.studentUsers.Remove(form3collection.studentUsers.Where(w => w.r.Name == curItem).FirstOrDefault());
            label3.Text += curItem;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            TeacherUser ak = new TeacherUser(form3collection.users.Where(w => w.Name == curItem).FirstOrDefault());
            g.teachers.Add(ak);
            label4.Text += $"{curItem} " ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (textBox2.Text != string.Empty)
            {
                g.NameOfGroup = textBox2.Text;
                if (form3collection.groups.Any(f=>f.NameOfGroup== textBox2.Text))
                {
                    form3collection.groups.Remove((form3collection.groups.Where(f => f.NameOfGroup == textBox2.Text)).FirstOrDefault());
                }
                form3collection.groups.Add(g);
                this.Close();
                Application.OpenForms[1].Visible = true;
            }

        }
    }
}
