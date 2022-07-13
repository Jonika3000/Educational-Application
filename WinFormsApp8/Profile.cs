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
    public partial class Profile : Form
    {
        User u = new User();
        Form parent = new Form();
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(User u , Form f)
        {
            InitializeComponent();
            this.u = u;
            parent = f;
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e )
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.ShowDialog();// открываем окно
            string FileName = openFile.FileName;// берем полный адрес картинки            
            pictureBox1.ImageLocation = FileName;// грузим картинку в pictureBox
            
            u.icon = pictureBox1.Image;
        }
    }
}
