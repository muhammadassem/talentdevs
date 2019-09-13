namespace MuhammadAssem.Migrations
{
    using MuhammadAssem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<MuhammadAssem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MuhammadAssem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Department department = new Department
            {
                DepName = "IT",
                Employees = new List<Employee>()
                {
                    new Employee
                    {
                        FristName = "employee1first",
                        LastName = "employee1last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee2first",
                        LastName = "employee2last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee3first",
                        LastName = "employee3last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee4first",
                        LastName = "employee4last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee5first",
                        LastName = "employee5last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee6first",
                        LastName = "employee6last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee7first",
                        LastName = "employee7last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee8first",
                        LastName = "employee8last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee9first",
                        LastName = "employee1last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee9first",
                        LastName = "employee1last",
                        DOB = new DateTime(2019, 11, 3)
                    }
                }
            };

            Department department2 = new Department
            {
                DepName = "CS",
                Employees = new List<Employee>()
                {
                    new Employee
                    {
                        FristName = "employee1first",
                        LastName = "employee1last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee2first",
                        LastName = "employee2last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee3first",
                        LastName = "employee3last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee4first",
                        LastName = "employee4last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee5first",
                        LastName = "employee5last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee6first",
                        LastName = "employee6last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee7first",
                        LastName = "employee7last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee8first",
                        LastName = "employee8last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee9first",
                        LastName = "employee1last",
                        DOB = new DateTime(2019, 11, 3)
                    },

                    new Employee
                    {
                        FristName = "employee9first",
                        LastName = "employee1last",
                        DOB = new DateTime(2019, 11, 3)
                    }
                }
            };

            context.Departments.AddOrUpdate(department);
            context.Departments.AddOrUpdate(department2);

            base.Seed(context);
        }
    }
}
