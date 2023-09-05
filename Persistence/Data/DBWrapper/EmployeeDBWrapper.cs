using Entities;

namespace Persistence.Data.DBWrapper
{
    public class EmployeeDBWrapper : IEmployeeDBWrapper
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeDBWrapper(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public List<Employee> EmployeeListGet()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}