using FirstAPPWithAPI.Data;
using FirstAPPWithAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace FirstAPPWithAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppdbContext _dbContext;
        private readonly ILogger<EmployeeController> logger;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public EmployeeController(AppdbContext dbContext,ILogger<EmployeeController> logger)
        {
            this._dbContext = dbContext;
            this.logger = logger;

        }

        [HttpGet]
        [Route("")]
        public async Task <ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var record = await _dbContext.Set<Employee>().ToListAsync();
            return Ok(record);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(int Id)
        {
            var record = await _dbContext.Set<Employee>().FindAsync(Id);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostRecord( Employee employee)
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
        public async Task <IActionResult> UpdateData(Employee employee)
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
        public async Task<IActionResult> DeleteData( int id )
        {
            var ExistingEmp = await _dbContext.Set<Employee>().FindAsync(id);
            _dbContext.Set<Employee>().Remove(ExistingEmp!);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DData( int id )
        {
            var ExistingEmp = await _dbContext.Set<Employee>().FindAsync(id);
            _dbContext.Set<Employee>().Remove(ExistingEmp!);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
