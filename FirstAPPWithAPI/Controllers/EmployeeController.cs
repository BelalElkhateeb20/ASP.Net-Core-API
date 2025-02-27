using FirstAPPWithAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace FirstAPPWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppdbContext _dbContext;

        public EmployeeController(AppdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("")]
        public ActionResult <IEnumerable<Employee>> GetAll()
        {           
            var record = _dbContext.Set<Employee>().ToList;
            return Ok(record);
        }
        [HttpGet]
        [Route("id")]
        public ActionResult <Employee> Get(int Id)
        {
            var record = _dbContext.Set<Employee>().Find(Id);
            return record == null ? NotFound() : Ok(record);
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateRecord(Employee employee)
        {
            if (employee==null)
                Console.WriteLine("Invalid");
            else
            _dbContext.Set<Employee>().Add(employee);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public ActionResult UpdateData(Employee employee)
        {
            var ExistingEmp = _dbContext.Set<Employee>().Find(employee.Id);
            ExistingEmp!.FirstName = employee.FirstName;
            ExistingEmp.Location = employee.Location;
            _dbContext.Set<Employee>().Update(ExistingEmp);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteData( int id )
        {
            var ExistingEmp = _dbContext.Set<Employee>().Find(id);
            _dbContext.Set<Employee>().Remove(ExistingEmp!);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
