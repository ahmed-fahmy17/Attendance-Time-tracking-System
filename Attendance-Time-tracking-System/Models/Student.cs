﻿using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Student : User
    {
        [StringLength(100, MinimumLength = 10)]
        public string University { get; set; }
        [StringLength(100, MinimumLength = 10)]
        public string Faculty { get; set; }
        [StringLength(100, MinimumLength = 10)]
        public string Specialization { get; set; }
        public int GradYear { get; set; }
        public bool Status { get; set; }

    }
}
