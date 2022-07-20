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
            listBox1.Items.Clear();
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            //var range = form3collection.studentUsers.Where(n => n.r.Name != string.Empty);
            foreach(var student in form3collection.studentUsers)
            {
                if(student.r.Name != null && student.InGroup==false)
                listBox1.Items.Add(student.r.Name);
            }
        }
        void AddListBoxTeachers()
        {
            listBox1.Items.Clear();
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            foreach (var student in form3collection.users)
            {
                if(student.Type == "Teacher" && student.Name != null)
                listBox2.Items.Add(student.Name);
            }
        }
        void DeleteTeacherList()
        {
            string curItem = listBox2.SelectedItem.ToString();
            listBox2.Items.Remove(curItem);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            string curItem;
            if (listBox2.SelectedItem.ToString() != null)
            {
                 curItem = listBox1.SelectedItem.ToString();
                g.users.Add(form3collection.studentUsers.Where(w => w.r.Name == curItem).FirstOrDefault());
                form3collection.studentUsers.Where(w => w.r.Name == curItem).Select(w => { w.InGroup = true; return w; }).ToList();
                //form3collection.studentUsers.Remove(form3collection.studentUsers.Where(w => w.r.Name == curItem).FirstOrDefault());
                label3.Text += $"{curItem} ";
                AddListBoxStudents();
            }
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string curItem; 
            if (listBox2.SelectedItem.ToString() != null)
            {
                 curItem = listBox2.SelectedItem.ToString();
                var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
                TeacherUser ak = new TeacherUser(form3collection.users.Where(w => w.Name == curItem).FirstOrDefault());
                g.teachers.Add(ak);
                label4.Text += $"{curItem} ";
                DeleteTeacherList();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (textBox2.Text != string.Empty && g.users.Count>0)
            {
                g.NameOfGroup = textBox2.Text;
                if (form3collection.groups.Any(f=>f.NameOfGroup== textBox2.Text))
                {
                    form3collection.groups.Remove((form3collection.groups.Where(f => f.NameOfGroup == textBox2.Text)).FirstOrDefault());
                }
                form3collection.groups.Add(g);
                for (int i = 0; i < g.users.Count; i++)
                    form3collection.studentUsers.Where(q => q.r.Name == g.users[i].r.Name).Select(c => { c.Group = g.NameOfGroup; return c; }).ToList() ;
                
                this.Close();
                Application.OpenForms[1].Visible = true;
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Visible = true;
            this.Close();
        }
    }
}
