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
    public partial class SeeSchedule : Form
    {
        public SeeSchedule()
        {
            InitializeComponent();
        }
        public SeeSchedule(TeacherUser tc)
        {
            InitializeComponent();
            foreach(var item in tc.schedule.schedule)
            {
                listBox1.Items.Add(item.Key);
                listBox1.Items.Add(item.Value);
            }
        }
        public SeeSchedule(StudentUser su)
        {
            InitializeComponent();
            foreach (var item in su.marks)
            {
                listBox1.Items.Add(item.Key);
                listBox1.Items.Add(item.Value);
            }
        }
    }
}
