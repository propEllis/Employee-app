using Entities;

namespace Persistence.Data.DBWrapper
{
    public interface IEmployeeDBWrapper
    {
        List<Employee> EmployeeListGet();
        Employee GetEmployeeById(int id);
        Employee SaveEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}