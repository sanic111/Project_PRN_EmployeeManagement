﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public partial class EmployeeAttendance
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan? CheckIn { get; set; }

        public TimeSpan? CheckOut { get; set; }

        public string? Status { get; set; }
    }
}