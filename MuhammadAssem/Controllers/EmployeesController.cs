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
using MuhammadAssem.Models.Repos;

namespace MuhammadAssem.Controllers
{
    public class EmployeesController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IEmployeeRepository<Employee> employeeRepository;
        private IDepartmentRepository<Department> departmentRepository;

        // GET: api/Employees

        public EmployeesController()
        {
            this.employeeRepository = new EmployeeRepository();
            this.departmentRepository = new DepartmentRepository();
        }

        [HttpGet]
        public List<EmployeeViewModel> Employees()
        {
            var dbEmployees = this.employeeRepository.List();

            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            foreach(var emp in dbEmployees)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    DepartmentId = emp.DepartmentId,
                    DOB = emp.DOB.Date,
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

            foreach (var department in this.departmentRepository.List())
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

            Employee employee = this.employeeRepository.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            

            var findedViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                FristName = employee.FristName,
                LastName = employee.LastName,
                DOB = employee.DOB.Date,
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

            //db.Entry(employee).State = EntityState.Modified;

            this.employeeRepository.Update(id, employee);

            try
            {
                this.employeeRepository.Save();
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

            this.employeeRepository.Add(employee);
            this.employeeRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = this.employeeRepository.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            this.employeeRepository.Delete(id);
            this.employeeRepository.Save();

            return Ok(employee);
        }

        

        private bool EmployeeExists(int id)
        {
            return this.employeeRepository.Exists(id) ;
        }
    }
}