using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MuhammadAssem.Models.Repos
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private ApplicationDbContext context;

        public EmployeeRepository()
        {
            this.context = new ApplicationDbContext();
        }
        public void Add(Employee entity)
        {
            this.context.Employees.Add(entity);

        }

        public void Delete(int id)
        {
            var employee = this.Find(id);
            this.context.Employees.Remove(employee);
        }

        public Employee Find(int id)
        {
            var employee = this.context.Employees.Include(emp => emp.Department).SingleOrDefault(emp => emp.Id == id);

            return employee;
        }

        public IList<Employee> List()
        {
            return this.context.Employees.Include(emp => emp.Department).ToList();
        }

        public void Update(int id, Employee entity)
        {
            var employee = this.Find(id);
            var department = this.context.Departments.Find(entity.DepartmentId);

            employee.Id = entity.Id;
            employee.FristName = entity.FristName;
            employee.LastName = entity.LastName;
            employee.DOB = entity.DOB;
            employee.Department.DepName = department.DepName;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public Boolean Exists(int id)
        {
            return this.context.Employees.Count(emp => emp.Id == id) > 0;
        }
    }
}