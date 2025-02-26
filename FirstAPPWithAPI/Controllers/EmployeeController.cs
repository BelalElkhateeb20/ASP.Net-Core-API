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
        [Route("")]
        public ActionResult deleteData( int id )
        {
            var ExistingEmp = _dbContext.Set<Employee>().Find(id);
            _dbContext.Set<Employee>().Remove(ExistingEmp!);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
