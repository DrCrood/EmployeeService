using System;
using System.Collections.Generic;
using EmployeeServiceAPI.Interface;
using EmployeeDataParser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace EmployeeServiceAPI.Controllers
{
    [ApiController]
    [Route("records/")]
    public class EmployeeServiceController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IEmployeeDataService _dataService;

        public EmployeeServiceController(ILogger<EmployeeServiceController> logger, IEmployeeDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Employee AddEmployee([FromBody] string record)
        {
            if(String.IsNullOrEmpty(record))
            {
                return null;
            }

            _logger.LogInformation("Post success.");
            return _dataService.AddEmployee(record);
        }

        [HttpGet]
        [Route("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetRecordsSortByLastName()
        {
            return _dataService.GetEmployeeSortByLastName();
        }

        [HttpGet]
        [Route("birthdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetRecordsSortByDob()
        {
            return _dataService.GetEmployeeSortByBirthDate();
        }

        [HttpGet]
        [Route("color")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetRecordSortByFavColor()
        {
            return _dataService.GetEmployeeSortByFavriteColor();
        }
    }
}
