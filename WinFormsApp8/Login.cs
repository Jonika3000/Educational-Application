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
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = comboBox1.SelectedItem.ToString() ;
            MessageBox.Show(selected);
        }
    
        void First (object sender , EventArgs e )
        {
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Teacher");
            comboBox1.Items.Add("Dispatching");
            User d = new User();
            d.Password = "Admin";
            d.Name = "Admin";
            users.Add(d);
        }
        void ButtonLogin (object sender , EventArgs e)
        {
            User r = new User();
            r.Login = textBox1.Text;
            r.Password = textBox2.Text;
            var d = users.Where(a => a.Name == r.Name && a.Password == r.Password).FirstOrDefault();

            if (d != null)
            {

                 if (d.Type == "Student")
                {

                }
                else if (d.Type == "Teacher")
                {

                }
                else if (d.Type == "Dispatching")
                {

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
            User ro = new User();
            //ro.Register();
            var d = users.Where(a => a.Name == ro.Name).FirstOrDefault();

            if (d == null)
            {
                users.Add(ro);
                Console.WriteLine("Ready");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("User already registered");
                Console.ReadKey();
            }
        }
    }
}