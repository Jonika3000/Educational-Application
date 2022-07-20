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
        public List<Subject> subjects = new List<Subject>();
        public List<Group> groups = new List<Group>();
        public List<StudentUser> studentUsers = new List<StudentUser>();
        public List<TeacherUser> teacherUsers = new List<TeacherUser>();
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
                using (FileStream fs = new FileStream("UsersTeacher.json", FileMode.OpenOrCreate))
                {

                    teacherUsers = JsonSerializer.Deserialize<List<TeacherUser>>(fs);
                }
                using (FileStream fs = new FileStream("UserStudents.json", FileMode.OpenOrCreate))
                {

                    studentUsers = JsonSerializer.Deserialize<List<StudentUser>>(fs);
                }
                using (FileStream fs = new FileStream("Subjects.json", FileMode.OpenOrCreate))
                {

                    subjects = JsonSerializer.Deserialize<List<Subject>>(fs);
                }
                using (FileStream fs = new FileStream("Groups.json", FileMode.OpenOrCreate))
                {

                    groups = JsonSerializer.Deserialize<List<Group>>(fs);
                }
            }
            catch (Exception ex)
            {

            }

        }

        void SerelUsers()
        {
            using var stream1 = File.Create("UserStudents.json");
            JsonSerializer.SerializeAsync(stream1, studentUsers);

            using var stream = File.Create("user.json");
            using var stream2 = File.Create("UsersTeacher.json");

            using var stream3 = File.Create("Groups.json");
            using var stream4 = File.Create("Subjects.json");
            JsonSerializer.SerializeAsync(stream, users);


            JsonSerializer.SerializeAsync(stream2, teacherUsers);
            JsonSerializer.SerializeAsync(stream3, groups);
            JsonSerializer.SerializeAsync(stream4, subjects);
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
                selected = comboBox1.SelectedItem.ToString();

        }

        void First(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Teacher");
            comboBox1.Items.Add("Dispatching");
            Text = "Login";
            this.Icon = new Icon("book_ico.ico");

            //LoadUser();
        }
        void ButtonLogin(object sender, EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;
            var d = users.Where(a => a.Login == r.Login && a.Password == r.Password).FirstOrDefault();
            if (textBox1 == null && textBox2 == null)
            {
                label3.Visible = true;
                label3.Text = "All fields are not filled";
                this.label3.ForeColor = System.Drawing.Color.Red;
            }
            else if (d != null)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                if (d.Type == "Student")
                {
                    this.Hide();
                    Student s = new Student(d);
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

        void ButtonRegister(object sender, EventArgs e)
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
                    if (r.Type == "Student")
                    {
                        StudentUser student = new StudentUser(r);
                        studentUsers.Add(student);
                    }
                    else if (r.Type == "Teacher")
                    {
                        TeacherUser t = new TeacherUser(r);
                        teacherUsers.Add(t);
                    }
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
        void Error(string ex)
        {
            label3.Visible = true;
            label3.Text = ex;
            this.label3.ForeColor = System.Drawing.Color.Red;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //SerelUsers();
            this.Close();
        }
    }
}