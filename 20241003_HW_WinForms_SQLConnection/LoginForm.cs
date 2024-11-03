namespace _20241003_HW_WinForms_SQLConnection
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string Email
        {
            get => txtEmail.Text;
        }

        public string Password
        {
            get => txtPassword.Text;
        }
    }
}
