using System;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class HomeUserControl : UserControl
    {
        public HomeUserControl()
        {
            InitializeComponent();
        }

        private void HomeUserControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill; 
        }

        private void panelMainContent_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
