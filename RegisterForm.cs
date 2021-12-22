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
    public partial class RegisterForm : Form
    {
        private ManageTeacher manageTeacher = new ManageTeacher();
        public RegisterForm()
        {
            InitializeComponent();
        }

        //private void textBox5_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            manageTeacher.LoadData();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            
            //TODO do register new account
            string error = "";
            if (string.IsNullOrWhiteSpace(textBox_Username.Text))
                error += "Username is required.\n";
            if (textBox_Username.Text.Trim().Length < 3)
                error += "Username requires at least 3 characters.\n";
            if (string.IsNullOrWhiteSpace(textBox_Password.Text))
                error += "Password is required.\n";
            if (textBox_Password.Text != textBox_Confirm_Password.Text)
                error += "Password and Confirm password must be identical.";

            if(error.Length > 0 )
            {
                MessageBox.Show(error);
            }
            else
            {
                manageTeacher.Teachers.Add(new Teacher
                {
                    Username = textBox_Username.Text.Trim(),
                    Password = textBox_Password.Text.Trim(),
                    Phone = textBox_Telephone.Text.Trim(),
                    QuestionNo = comboBox_Questions.SelectedIndex,
                    Answer = textBox_Answer.Text.Trim()

                }) ;

                manageTeacher.SaveData();
                DialogResult = DialogResult.OK;
                MessageBox.Show("Registration Successful");
                Close();
               

            }
        }

        private void buttonClick_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
