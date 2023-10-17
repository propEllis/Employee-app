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

        public bool DeleteEmployee(int id)
        {
            var _employeeSkalSlettes = _employeeContext.Employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            if (_employeeSkalSlettes is null)
            {
                throw new Exception("Ansatt finnes ikke i databasen");
            }
            else
            {
                try
                {
                    _employeeContext.Remove(_employeeSkalSlettes);
                    if (_employeeContext.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else return false;
                }
                catch (Exception e)
                {
                    var _error = e.Message.ToString();
                    return false;
                }
            }
        }

        public List<Employee> EmployeeListGet()
        {
            return _employeeContext.Employees.ToList();

            // var employeesList = new List<Employee>();
            // List<Employee> employeesList;

            /*
            var employeesList = new List<Employee>()
                {
                    new Employee()
                     {
                        EmployeeId = 1,
                        Fornavn = "Lykke",
                        Etternavn = "Liten",
                        Adresse = "Kjærlighetsstien 6",
                        Telefonnr = "66 66 66 66"
                    },
                    new Employee()
                    {
                        EmployeeId = 2,
                        Fornavn = "Hoppsi",
                        Etternavn = "Deisi",
                        Adresse = "Hoppegåsveien 8",
                        Telefonnr = "88 88 88 88"
                    },
                    new Employee()
                    {
                        EmployeeId = 3,
                        Fornavn = "Boppi",
                        Etternavn = "Loppi",
                        Adresse = "Schvoppegata 16",
                        Telefonnr = "16 16 16 16"
                    }
                };
                return employeesList;
                */
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeContext.Employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            if (employee == null)
            {
                throw new ArgumentNullException("Ansatt ikke funnet!");
            }
            return employee;
        }

        public Employee SaveEmployee(Employee employee)
        {
            _employeeContext.Add(employee);
            //_employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }
    }
}
