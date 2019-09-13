using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuhammadAssem.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public int? DepartmentId { get; set; }

        public List<DepartmentViewModel> DepartmentsList { get; set; }

        public string DepartmentName { get; set; }
    }
}