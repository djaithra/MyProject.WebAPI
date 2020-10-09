using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.Models;

namespace MyProject.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public DataController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public IEmployeeRepository EmployeeRepository { get; }

        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return EmployeeRepository.GetAllEmployee(); 
        }       
    }
}
