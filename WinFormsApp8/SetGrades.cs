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
        List<Group> groups = new List<Group>();
        public SetGrades()
        {
            InitializeComponent();
        }
        public void FindGroup()
        {
            var d = groups.Where(group => group.NameOfGroup == textBox1.Text).FirstOrDefault();
            
        }
    }
}
