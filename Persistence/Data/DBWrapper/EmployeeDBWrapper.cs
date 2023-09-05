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
           
            // return _employeeContext.Employees.ToList();
           var employeesList = new List<Employee>();
            employeesList.Add(new Employee() {
                Id = 1,
                Fornavn = "Lykke",
                Etternavn = "Liten",
                Adresse = "Kjærlighetsstien 6",
                Telefonnr = "66 66 66 66"
                }
            );
            employeesList.Add(new Employee() {
                Id = 2,
                Fornavn = "Hoppsi",
                Etternavn = "Deisi",
                Adresse = "Hoppegåsveien 8",
                Telefonnr = "88 88 88 88"
                }
            );
            employeesList.Add(new Employee() {            
                Id = 3,
                Fornavn = "Boppi",
                Etternavn = "Loppi",
                Adresse = "Schvoppegata 16",
                Telefonnr = "16 16 16 16"
                }
            );
            return employeesList;
        }
    }
}
