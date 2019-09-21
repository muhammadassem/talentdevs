using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuhammadAssem.Models.Repos
{
    public class DepartmentRepository : IDepartmentRepository<Department>
    {
        private ApplicationDbContext context;

        public DepartmentRepository()
        {
            this.context = new ApplicationDbContext();
        }
        public void Add(Department entity)
        {
            this.context.Departments.Add(entity);

        }

        public void Delete(int id)
        {
            var department = this.Find(id);
            this.context.Departments.Remove(department);
        }

        public Department Find(int id)
        {
            var department = this.context.Departments.SingleOrDefault(dep => dep.Id == id);

            return department;
        }

        public IList<Department> List()
        {
            return this.context.Departments.ToList();
        }

        public void Update(int id, Department entity)
        {
            var department = this.Find(id);

            department.Id = entity.Id;
            department.DepName = entity.DepName;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public Boolean Exists(int id)
        {
            return this.context.Departments.Count(dep => dep.Id == id) > 0;
        }
    }
}