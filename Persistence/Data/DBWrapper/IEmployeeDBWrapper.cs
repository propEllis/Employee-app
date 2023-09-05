using Entities;

namespace Persistence.Data.DBWrapper
{
    public interface IEmployeeDBWrapper
    {
        List<Employee> EmployeeListGet();
    }
}