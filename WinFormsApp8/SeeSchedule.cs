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
            DateTime timelesson = new DateTime();
            DateTime timeNow = DateTime.Now;
            foreach (var item in tc.schedule.schedule)
            {
                if (item.Key>timeNow)
                {
                    timelesson = item.Key;
                    timelesson = timelesson.AddHours(item.Value.time.Hour);
                    timelesson = timelesson.AddMinutes(item.Value.time.Minute);
                    listBox1.Items.Add($"{item.Key}-{timelesson} -> {item.Value.Name}");
                }
                
            }
        }
        public SeeSchedule(StudentUser su)
        {
            InitializeComponent();
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            var c = form3collection.groups.Where(q => q.users.Contains(su));
            DateTime timelesson = new DateTime();
            DateTime timeNow = DateTime.Now;
            foreach (var item in c)
            {
                foreach(var i in  item.schedule.schedule)
                {
                    if (i.Key > timeNow)
                    {
                        timelesson = i.Key;
                        timelesson = timelesson.AddHours(i.Value.time.Hour);
                        timelesson = timelesson.AddMinutes(i.Value.time.Minute);

                        listBox1.Items.Add($"{i.Key}-{timelesson} -> {i.Value.Name}");
                    }
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
