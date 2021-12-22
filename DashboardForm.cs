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
    public partial class DashboardForm : Form
    {
        Teacher teacher;
        ManageAttendance manageAttendance;
        //public BindingSource BindingSource { get; set; } = new BindingSource();
        public DashboardForm(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            manageAttendance = new ManageAttendance(teacher.Username);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            manageAttendance.LoadData();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            //ToDO sample Data (Make it real)
            
            //BindingSource.DataSource = manageAttendance.Attendances;
            //foreach(var a in manageAttendance.Attendances)
            //{
            //    bindingSource1.Add(a);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manageAttendance.LoadData();
            bindingSource1.Clear();
            DateTime date = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                dateTimePicker1.Value.Day);

            var lst = from a in manageAttendance.Attendances
                      where (a.Date - date).TotalDays < 1 &&
                      a.Subject == comboBox1.SelectedItem.ToString()
                      && a.Session == comboBox2.SelectedIndex
                      select a;

            if (lst.Count() == 0)
            {
                Attendance a1, a2, a3, a4;

                manageAttendance.Attendances.Add(a1 = new Attendance { No = 1, Name = "Sokvimean",
                    Date = dateTimePicker1.Value, Session = comboBox2.SelectedIndex, Subject = comboBox1.SelectedItem.ToString() });
                manageAttendance.Attendances.Add(a2 = new Attendance { No = 2, Name = "Piseth",
                    Date = dateTimePicker1.Value,
                    Session = comboBox2.SelectedIndex,
                    Subject = comboBox1.SelectedItem.ToString()
                });
                manageAttendance.Attendances.Add(a3 = new Attendance { No = 3, Name = "Chor daphea",
                    Date = dateTimePicker1.Value,
                    Session = comboBox2.SelectedIndex,
                    Subject = comboBox1.SelectedItem.ToString()
                });
                manageAttendance.Attendances.Add(a4 = new Attendance { No = 4, Name = "Thanit",
                    Date = dateTimePicker1.Value,
                    Session = comboBox2.SelectedIndex,
                    Subject = comboBox1.SelectedItem.ToString()
                });

                bindingSource1.Add(a1);
                bindingSource1.Add(a2);
                bindingSource1.Add(a3);
                bindingSource1.Add(a4);

            }else
            {
                int i = 1;
                foreach(var a in lst)
                {
                    a.No = i++;
                    bindingSource1.Add(a);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            manageAttendance.SaveData();
        }
    }
}
