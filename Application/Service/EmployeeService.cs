using System.Net.Http.Headers;
using Application.Dtos;
using AutoMapper;
using Entities;
using Persistence.Data.DBWrapper;

namespace Application.Service
{
    public interface IEmployeeService
    {
        List<EmployeeDto> HentEmployeeListe();
        EmployeeDto HentEmployeeFraId(int id);
        EmployeeDto LagreEmployee(CreateEmployeeDto createEmployeeDto);
        bool SlettEmployee(int id);
        EmployeeDto OppdaterEmployee(EmployeeDto employee);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDBWrapper _employeeDBWrapper;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeDBWrapper employeeDBWrapper, IMapper mapper)
        {
            _employeeDBWrapper = employeeDBWrapper ?? throw new ArgumentNullException(nameof(employeeDBWrapper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public EmployeeDto HentEmployeeFraId(int id)
        {
            var response = _employeeDBWrapper.GetEmployeeById(id);
            return _mapper.Map<EmployeeDto>(response);
        }

        public List<EmployeeDto> HentEmployeeListe()
        {
            var response = _employeeDBWrapper.EmployeeListGet();
            return _mapper.Map<List<EmployeeDto>>(response);
        }
        
        public EmployeeDto LagreEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var employeeObj = new Employee()
            {
                Fornavn = createEmployeeDto.FirstName,
                Etternavn = createEmployeeDto.LastName,
                Adresse = createEmployeeDto.Address,
                Telefonnr = createEmployeeDto.PhoneNumber
            };
            var response = _employeeDBWrapper.SaveEmployee(employeeObj);

            var employeeDtoObj = new EmployeeDto()
            {
                Id = response.EmployeeId,
                FirstName = response.Fornavn,
                LastName = response.Etternavn,
                Address = response.Adresse,
                PhoneNumber = response.Telefonnr
            };
            return employeeDtoObj;
        }

        public EmployeeDto OppdaterEmployee(EmployeeDto employee)
        {
            var employeeOppdateres = new Employee()
            {
                EmployeeId = employee.Id,
                Fornavn = employee.FirstName,
                Etternavn = employee.LastName,
                Adresse = employee.Address,
                Telefonnr = employee.PhoneNumber
            };
            var response = _employeeDBWrapper.UpdateEmployee(employeeOppdateres);

            var employeeDtoObj = new EmployeeDto()
            {
                Id = response.EmployeeId,
                FirstName = response.Fornavn,
                LastName = response.Etternavn,
                Address = response.Adresse,
                PhoneNumber = response.Telefonnr
            };
            return employeeDtoObj;
        }

        public bool SlettEmployee(int id)
        {
            return _employeeDBWrapper.DeleteEmployee(id);

        }
    }
}