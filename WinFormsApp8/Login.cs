using System.Text.Json;

namespace WinFormsApp8
{
    public partial class Login : Form
    {
        string selected;
        ConsoleKeyInfo k;
        string logintmp;
        string passwordtmp;
        List<User> users = new List<User>();
        public Login()
        {
            InitializeComponent();
            Shown += First;
            
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            button2.Click += ButtonLogin;
            button3.Click += ButtonRegister;
        }
        void LoadUser()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                users = JsonSerializer.Deserialize<List<User>>(fs);
            }
             
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = comboBox1.SelectedItem.ToString() ;
             
        }
    
        void First (object sender , EventArgs e )
        {
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Teacher");
            comboBox1.Items.Add("Dispatching");
            
            //LoadUser();
        }
        void ButtonLogin (object sender , EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;
            var d = users.Where(a => a.Name == r.Name && a.Password == r.Password).FirstOrDefault();
            if (textBox1 == null && textBox2==null)
            {
                label3.Visible = true;
                label3.Text = "All fields are not filled";
                this.label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (d != null)
            {

                 if (d.Type == "Student")
                {
                    this.Hide();
                    Student s = new Student(d , this);
                    s.ShowDialog();
                }
                else if (d.Type == "Teacher")
                {
                    this.Hide();
                    Teacher t = new Teacher(d);
                    t.ShowDialog();
                }
                else if (d.Type == "Dispatching")
                {
                    
                    this.Hide();
                    Dispatching t = new Dispatching(d);
                    t.ShowDialog();
                }
            }
            else
            {
                label3.Visible = true;
                label3.Text = "There is no such user";
                this.label3.ForeColor = System.Drawing.Color.Red;

            }
        }
        void ButtonRegister (object sender , EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;

            var d = users.Where(a => a.Name == r.Name).FirstOrDefault();

            if (d == null && selected != null)
            {
                r.Type = selected;
                r.icon = Image.FromFile("user ico.png");
                users.Add(r);
                label3.Visible = true;
                label3.Text = "You have registered successfully";
                this.label3.ForeColor = System.Drawing.Color.Green;
            }
            else if (d == null)
            {
                label3.Visible = true;
                label3.Text = "This user already exists";
                this.label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (selected != null)
            {
                label3.Visible = true;
                label3.Text = "Select user type";
                this.label3.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}