using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CarAgancyLogin
{
    public partial class DriverForm : Form
    {
        private string loggedInUsername;
        public DriverForm(string username)
        {
            InitializeComponent();
            this.loggedInUsername = username;
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Userhistory registerPage = new Userhistory(loggedInUsername);
            LoadUserControl(registerPage);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm registerPage = new ProfileForm(loggedInUsername);
            LoadUserControl(registerPage);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DriverForm driverForm = new DriverForm(loggedInUsername);
            driverForm.Show();

          
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
