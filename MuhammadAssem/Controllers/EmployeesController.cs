using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MuhammadAssem.Models;

namespace MuhammadAssem.Controllers
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employees
        [HttpGet]
        public List<EmployeeViewModel> Employees()
        {
            var dbEmployees = db.Employees.Include(e => e.Department).ToList();

            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            foreach(var emp in dbEmployees)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    DepartmentId = emp.DepartmentId,
                    DOB = emp.DOB,
                    FristName = emp.FristName,
                    LastName = emp.LastName,
                    Id = emp.Id,
                    DepartmentName = emp.Department.DepName
                };

                employees.Add(employeeViewModel);
            }

            return employees;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            var departmentsList = new List<DepartmentViewModel>();

            foreach (var department in db.Departments.ToList())
            {
                departmentsList.Add(new DepartmentViewModel
                {
                    Id = department.Id,
                    DepName = department.DepName
                });
            }

            if (id == 0)
            {
                var viewModel = new EmployeeViewModel
                {
                    DepartmentsList = departmentsList
                };

                return Ok(viewModel);
            }

            Employee employee = db.Employees.SingleOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            

            var findedViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                FristName = employee.FristName,
                LastName = employee.LastName,
                DOB = employee.DOB,
                DepartmentId = employee.Department.Id,
                DepartmentName = employee.Department.DepName,
                DepartmentsList = departmentsList
            };

            return Ok(findedViewModel);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}