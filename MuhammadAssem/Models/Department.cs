using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuhammadAssem.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}