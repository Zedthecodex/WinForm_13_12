using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_13_12
{
    public partial class LoginForm : Form
    {
        public bool IsLogin { get; set; } = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            DialogResult res = rf.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //TODO did register, go back to dashboard

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender,FormClosedEventArgs e)
        {
            if(!IsLogin)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsLogin = true;
            new DashboardForm().Show();
            Close();
        }
    }
}
