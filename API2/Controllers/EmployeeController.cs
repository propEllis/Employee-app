using Application.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [ApiController]
    [Route("api2/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet]
        public List<EmployeeDto> GetEmployeeList()
        {
            return _employeeService.GetEmployeeList();
        }

        [HttpGet]
        public EmployeeDto GetEmployeeById(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }
    }
}