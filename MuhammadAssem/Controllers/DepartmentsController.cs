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
    public class DepartmentsController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private DepartmentRepository departmentRepository;

        public DepartmentsController()
        {
            this.departmentRepository = new DepartmentRepository();
        }

        // GET: api/Departments
        public IList<Department> GetDepartments()
        {
            return this.departmentRepository.List();
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            if (id == 0)
            {
                return Ok(new Department());
            }
            Department department = this.departmentRepository.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.Id)
            {
                return BadRequest();
            }
            //var departmentDb = this.departmentRepository.Find(id);

            //departmentDb.DepName = department.DepName;
            //departmentDb.Id = department.Id;

            this.departmentRepository.Update(id, department);

            try
            {
                this.departmentRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.departmentRepository.Add(department);
            this.departmentRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            Department department = this.departmentRepository.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            this.departmentRepository.Delete(id);
            this.departmentRepository.Save();

            return Ok(department);
        }

        private bool DepartmentExists(int id)
        {
            return this.departmentRepository.Exists(id);
        }
    }
}