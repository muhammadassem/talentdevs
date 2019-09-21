using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuhammadAssem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}