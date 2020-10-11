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
        public DataController(IRepositoryWrapper repositoryWrapper,ILoggerManager logger)
        {
            RepositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        public IRepositoryWrapper RepositoryWrapper { get; }

        private readonly ILoggerManager _logger;

        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //Testing Logging

            //_logger.LogInfo("Here is info message from the controller.");
            //_logger.LogDebug("Here is debug message from the controller.");
            //_logger.LogWarn("Here is warn message from the controller.");
            //_logger.LogError("Here is error message from the controller.");

            //Testing Global Exceptions
            //_logger.LogInfo("Fetching all the Emlployees from the storage");           
            //throw new Exception("Exception while fetching all the students from the storage.");           

            //Getting Data
            return RepositoryWrapper.Employee.FindAll();
            //return RepositoryWrapper.Employee.FindByCondition(x => x.Id.Equals(2));            
        }       
    }
}
