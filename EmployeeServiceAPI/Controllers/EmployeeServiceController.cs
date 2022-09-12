using System;
using System.Collections.Generic;
using EmployeeServiceAPI.Interface;
using EmployeeDataParser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;

namespace EmployeeServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/records/")]
    public class EmployeeServiceController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IEmployeeDataService _dataService;

        public EmployeeServiceController(ILogger<EmployeeServiceController> logger, IEmployeeDataService dataService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService)); ;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> AddEmployee([FromBody] string record)
        {
            Employee employee = _dataService.ParseLine(record);
            if(employee is null || _dataService.EmployeeExists(employee))
            {
                return BadRequest();
            }

            _dataService.AddEmployee(employee);
            
            return employee;
        }

        [HttpGet]
        [Route("name")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetRecordsSortByLastName()
        {
            var employees = _dataService.GetEmployeeSortByLastName();
            if(employees is null)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return employees;
        }

        [HttpGet]
        [Route("birthdate")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetRecordsSortByDob()
        {
            var employees = _dataService.GetEmployeeSortByBirthDate();
            if (employees is null)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return employees;
        }

        [HttpGet]
        [Route("color")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> GetRecordSortByFavColor()
        {
            var employees = _dataService.GetEmployeeSortByFavriteColor();
            if (employees is null)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return employees;
        }

        /// <summary>
        /// This handles all exceptions in the request pipeline
        /// </summary>
        /// <returns>Error message</returns>
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem( detail: "Exception caught when processing the request.", title: context.Error.Message);
        }
    }
}
