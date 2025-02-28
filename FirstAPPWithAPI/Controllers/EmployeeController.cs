using FirstAPPWithAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        public async Task <ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var record = await _dbContext.Set<Employee>().ToListAsync();
            return Ok(record);
        }
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult <Employee>> GetByID(int Id)
        {
            var record = await _dbContext.Set<Employee>().FindAsync(Id);
            return record == null ? NotFound() : Ok(record);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateRecord(Employee employee)
        {
            if (employee==null)
                Console.WriteLine("Invalid");
            else
             await _dbContext.Set<Employee>().AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public async Task <ActionResult> UpdateData(Employee employee)
        {
            var ExistingEmp = await _dbContext.Set<Employee>().FindAsync(employee.Id);
            ExistingEmp!.FirstName = employee.FirstName;
            ExistingEmp.Location = employee.Location;
           _dbContext.Set<Employee>().Update(ExistingEmp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteData( int id )
        {
            var ExistingEmp = await _dbContext.Set<Employee>().FindAsync(id);
            _dbContext.Set<Employee>().Remove(ExistingEmp!);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
