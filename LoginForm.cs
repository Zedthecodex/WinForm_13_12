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
        private ManageTeacher manageTeacher = new ManageTeacher();
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
                Show();
                manageTeacher.LoadData();
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
            Teacher teacher = manageTeacher.Teachers.Find(
                t => t.Username == Username_Login.Text &&
                t.Password == Password_Login.Text);

            if (teacher != null)
            {

                IsLogin = true;
                new DashboardForm(teacher).Show();
                Close();

            }
            else MessageBox.Show("Invalid Username or Password");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            manageTeacher.LoadData();
        }
    }
}
