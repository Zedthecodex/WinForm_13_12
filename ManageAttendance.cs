using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Text;

namespace WinForm_13_12
{
    public class ManageAttendance
    {
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        readonly string FileName = "C:/Users/ASUS/source/repos/WinForm_13_12/teachers.csv";
        
        const string subject_Path = "C:/Users/ASUS/source/repos/WinForm_13_12/Subjects.csv";

        public string TeacherName { get; set; }= " ";



        public ManageAttendance(string teacherName)
        {
            TeacherName = teacherName;
            FileName = TeacherName + "-" + FileName;
        }
        
        private Image LoadImage(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch { return Properties.Resources._504_5040528_empty_profile_picture_png_transparent_png; }
        }
        public void LoadData()
        {
            if (!File.Exists(subject_Path)) return;
            var ts = from t in File.ReadAllLines(subject_Path).Skip(1)
                     let x = t.Split(',')
                     select new Attendance
                     {
                         Image_Path = x[0],
                         Name = x[1],
                         Status = x[2],
                         Remark = x[3],
                         Subject = x[4],
                         Session = int.Parse(x[5]),
                         Date = DateTime.Parse(x[6])
                     };
            Attendances.Clear();
            int i = 1;
            foreach(var t in ts)
            {
                t.No = i++;
                Attendances.Add(t);
            }
           
        }

        public void SaveData()
        {
            using (var fs = new FileStream(subject_Path, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Avatar,Name,Status,Remark,Subject,Session,Date");
                    foreach (var t in Attendances)
                    {
                        sw.WriteLine($"{t.Avatar},{t.Name},{t.Status},"
                            + $"{t.Remark},{t.Subject},{t.Session},{t.Date.ToShortDateString()}");
                    } //t.Date.ToShortDateString()
                }

            }
        }

    }
}