using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MuhammadAssem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}