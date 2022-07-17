﻿using System;
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
        List<Group> groups = new List<Group>();
        Group g = new Group();
        public SetGrades()
        {
            InitializeComponent();
            textBox1.TextChanged += FindGroup;
        }
        public void FindGroup(object sender,EventArgs e)
        {
            g = groups.Where(group => group.NameOfGroup == textBox1.Text).FirstOrDefault();
            listBox1.DataSource = g.users;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mark = Int32.Parse(textBox2.Text);
            foreach (var item in g.users)
            {
                if (item == listBox1.SelectedItem)
                {
                    item.AddMarks(mark, g.schedule);
                }
            }
        }
    }
}
