using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.Models;

namespace MyProject.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public DataController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }

        public IRepositoryWrapper RepositoryWrapper { get; }

        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return RepositoryWrapper.Employee.FindAll();
            //return RepositoryWrapper.Employee.FindByCondition(x => x.Id.Equals(2));            
        }       
    }
}
