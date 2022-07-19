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
        int num;
        Group g = new Group();
        public SetGrades()
        {
            InitializeComponent();
            textBox1.TextChanged += FindGroup;
            listBox1.SelectedIndexChanged += SelectedIndexChanged;
        }
        void SelectedIndexChanged(object sender , EventArgs e)
        {
            textBox2.Text = string.Empty;
        }
        public void FindGroup(object sender,EventArgs e)
        {
            DateTime b = DateTime.Now;
            try
            {
                int i = 0;
                var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
                g = form3collection.groups.Where(group => group.NameOfGroup == textBox1.Text).FirstOrDefault();
                foreach(var t in form3collection.groups)
                {
                    if (t.NameOfGroup == textBox1.Text)
                    {
                        num = i;
                        foreach (var c in t.users)
                            listBox1.Items.Add(c.r.Name);
                        foreach (var c2 in t.schedule.schedule)
                        {
                            if(c2.Key==b)
                            listBox2.Items.Add($"{c2.Value.Name}");

                        }
                        break;
                    }
                    i++;
                }
                //listBox1.DataSource = form3collection.groups.Where(group => group.NameOfGroup == textBox1.Text).Select(g => g.users);
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            string mark = textBox2.Text;
            if (mark != string.Empty)
            {
                string curItem = listBox1.SelectedItem.ToString();
                string curItem1 = listBox2.SelectedItem.ToString();
                if (curItem != string.Empty && curItem1 != string.Empty)
                {
                    Schedule tmp = new Schedule();
                    tmp = form3collection.groups.Where(group => group.NameOfGroup == textBox1.Text).Select(q => q.schedule).FirstOrDefault();
                    var c = tmp.schedule.Where(q => q.Value.Name == curItem1).FirstOrDefault();
                    Schedule n = new Schedule();
                    n.Add(c.Value, c.Key);
                    var student = form3collection.studentUsers.Where(q => q.r.Name == curItem).FirstOrDefault();
                    textBox2.Text = string.Empty;
                    student.AddMarks(mark, n);
                }
                else
                    Error("error data");
            }
            else
                Error("error data");
        }
        private void Error (string er)
        {
            MessageBox.Show("Error", er, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }
    }
}
