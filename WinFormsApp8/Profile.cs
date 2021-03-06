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
            Shown += First;
        }
        void First (object sender , EventArgs e)
        {
            pictureBox1.BackgroundImage = u.icon;
            var form3collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
            Text = "Change profile";
            this.Icon = new Icon("book_ico.ico");
            textBox1.Text = u.Name;
            textBox2.Text = u.Password;
            if (u.Type== "Student" )
            {
                foreach(var t in form3collection.groups)
                {
                    foreach(var c in t.users)
                            {
                        if (c.r.Name == u.Name)
                        {
                            textBox3.Text = c.Group;
                            break;
                        }
                    }
                }
                 
            }
             
            else  
            {
                textBox3.Text = "None";
                textBox3.ReadOnly = true;
            }
             
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e )
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.ShowDialog();// открываем окно
            string FileName = openFile.FileName;// берем полный адрес картинки            
            pictureBox1.BackgroundImage = Image.FromFile(FileName);// грузим картинку в pictureBox
            
            u.icon = pictureBox1.Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Application.OpenForms[1].Visible = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            u.Name = textBox1.Text;
            u.Password = textBox2.Text;
            //u.Group = textBox3.Text;
            u.icon = pictureBox1.BackgroundImage;
            var form2collection = Application.OpenForms.OfType<Login>().FirstOrDefault();
           
            if (null != form2collection)
            {
                
                var itemToRemove = form2collection.users.Single(r => r.Login == u.Login);
                form2collection.users.Remove(itemToRemove);
                form2collection.users.Add(u);
                 if (parent != null)
                {
                    if (parent.GetType() == typeof(Dispatching))
                {
                    var form3collection = Application.OpenForms.OfType<Dispatching>().FirstOrDefault();
                        if (null != form3collection)
                        {
                            form3collection.r = u;
                            form3collection.UpdateL();
                            form3collection.Visible = true;
                            this.Close();

                        }
                    }
                else if (parent.GetType() == typeof(Student))
                {
                    var form3collection = Application.OpenForms.OfType<Student>().FirstOrDefault();
                        if (null != form3collection)
                        {
                            form3collection.r = u;
                            form3collection.UpdateL();
                            form3collection.Visible = true;
                            this.Close();

                        }
                    }
                else if (parent.GetType() == typeof(Teacher))
                {
                    var form3collection = Application.OpenForms.OfType<Teacher>().FirstOrDefault();
                        if (null != form3collection)
                        {
                            form3collection.r = u;
                            form3collection.UpdateL();
                            form3collection.Visible = true;
                            this.Close();

                        }

                    }
                   
                }
                
               
                
            }
        }
    }
}
