using Application.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return _employeeService.HentEmployeeListe();
        }

        [HttpGet("{id}")]
        public EmployeeDto GetEmployeeById(int id)
        {
            return _employeeService.HentEmployeeFraId(id);
        }

        [HttpPost]
        public ActionResult<EmployeeDto> LagreEmployeeObjekt(CreateEmployeeDto createEmployeeDto)
        {
            return  _employeeService.LagreEmployee(createEmployeeDto);
        }

        [HttpDelete("{id}")]
        public bool DeleteEmployee(int id) 
        {
            return _employeeService.SlettEmployee(id);
            
        }
    }


}