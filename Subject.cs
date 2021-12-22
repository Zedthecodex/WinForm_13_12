using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace WinForm_13_12
{
    public class Subject
    {
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        string subject_Name { get; set; } = "Name Unassigned";

        string Time { get; set; } = "Awaiting Time assignment";

        string Level { get; set; } = "Unassigned";
    }
}