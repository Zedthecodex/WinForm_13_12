using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WinForm_13_12
{
    public class Attendance
    {
        public int No { get; set; } = 0;
        public Image Avatar { get; private set; } = Properties.Resources._504_5040528_empty_profile_picture_png_transparent_png;
        private string _path = "_504_5040528_empty_profile_picture_png_transparent_png";

        public string Image_Path
        {
            get => _path; set
            {
                _path = value;
                try { Avatar = Image.FromFile(_path); } catch { }
            }
        }
        public string Name { get; set; } = "Unknown";
        public string Status { get; set; } = "Absent";
        public string Remark { get; set; } = "";

        public string Subject { get; set; } = "Unknown";
        public int Session { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;


    }
}
