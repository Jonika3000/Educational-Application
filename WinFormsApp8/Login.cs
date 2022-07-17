using System.Text.Json;
using System.Text.RegularExpressions;

namespace WinFormsApp8
{
    public partial class Login : Form
    {
        string selected;
        string logintmp;
        string passwordtmp;
        DateTime t = new DateTime();
       public List<User> users = new List<User>();
        public Login()
        {
            InitializeComponent();
            Shown += First;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            button2.Click += ButtonLogin;
            button3.Click += ButtonRegister;
            textBox2.KeyPress += ButtonRegisterEx;
            textBox1.KeyPress += ButtonRegisterEx;
            LoadUser();
        }
        void LoadUser()
        {
            try
            {
                using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                {

                    users = JsonSerializer.Deserialize<List<User>>(fs);
                }
            }
            catch (Exception ex)
            {

            }
             
        }
        void Serel()
        {
            using var stream = File.Create("user.json");
              JsonSerializer.SerializeAsync(stream, users);
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
            Text = "Login";
            this.Icon = new Icon("book_ico.ico");

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
                    Student s = new Student(d );
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
        void ButtonRegisterEx(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            char Symbol1 = e.KeyChar;
            if (!Regex.Match(Symbol, @"^\w+$").Success)
            {
                e.Handled = true;
            }
            if (Symbol1 == 8 || Symbol1 == 32)
            {
                e.Handled = false;
            }
        }

        void ButtonRegister (object sender , EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;
            if (textBox2.Text.Length >= 6)
            {
                var d = users.Where(a => a.Login == r.Login).FirstOrDefault();

                if (d == null && selected != null && r.Password != string.Empty && r.Login != string.Empty)
                {
                    r.Type = selected;
                    r.icon = Image.FromFile("user ico.png");
                    users.Add(r);
                    label3.Visible = true;
                    label3.Text = "You have registered successfully";
                    this.label3.ForeColor = System.Drawing.Color.Green;
                }
                else if (d != null)
                {
                    Error("This user already exists");
                }
                else if (selected == null)
                {
                    Error("Select user type");
                }
                else if (r.Password == null && r.Login == null)
                {
                    Error("Not all fields are filled");
                }
            }
               else
            {
                Error("Password is too small");
            }

        }
        void Error (string ex)
        {
            label3.Visible = true;
            label3.Text = ex;
            this.label3.ForeColor = System.Drawing.Color.Red;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Serel();
            this.Close();
        }
    }
}