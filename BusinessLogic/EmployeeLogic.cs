using Data.Model;
using Data.Access;


namespace Business.Logic
{
    public class EmployeeLogic
    {

        private readonly EmployeeApi _employeeApi;
        private readonly HttpClient _httpClient;

        public List<Employee>? employees;

        public EmployeeLogic(HttpClient httpClient, List<string> methods)
        {
            _httpClient = httpClient;

            _employeeApi = new EmployeeApi(_httpClient, methods);
        }

        private async Task<List<Employee>> getAll() {

            var employees = await this._employeeApi.GetEmployeesAsync();
            return employees;
        }

        private async Task<List<Employee>> getById(int? employeeId)
        {
            List<Employee> result = new List<Employee>();

            var employee = await this._employeeApi.GetEmployeeByIdAsync(employeeId);

            if (employee != null)
                if (employee.EmployeeName != null) result.Add(employee);

            return result;
        }

        public async Task<List<Employee>> queryEmployee(int? employeeId)
        {
            if (employeeId == null)
            {
                var employees = await getAll();
                return employees;
            }
            else
            {
                var selectedEmployee = await getById(employeeId);
                return selectedEmployee;
            }
        }

        public async Task<decimal> calculateAnnualSalary(int _employeeId)
        {
            decimal annualSalary = 0;
            
            List<Employee> selectedEmployee =  await getById(_employeeId);

            if(selectedEmployee!=null)
                if(selectedEmployee.Count>0)
                    annualSalary = selectedEmployee[0].Annualsalary;

            return annualSalary;

        }


        // dummy data to test and debug:  API does not accept too many requets
        public async Task<List<Employee>> getDummyData(int? employeeId)
        {
 
            var result = new List<Employee>() {
                    new Employee { Id = 1, EmployeeName = "Alice1", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 2, EmployeeName = "Alice2", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 3, EmployeeName = "Alice3", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 4, EmployeeName = "Alice4", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 5, EmployeeName = "Alice5", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 6, EmployeeName = "Alice6", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 7, EmployeeName = "Alice7", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 8, EmployeeName = "Alice8", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 9, EmployeeName = "Alice9", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 10, EmployeeName = "Alice10", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 11, EmployeeName = "Alice11", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 12, EmployeeName = "Alice12", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 13, EmployeeName = "Alice13", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 14, EmployeeName = "Alice14", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 15, EmployeeName = "Alice15", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" },
                    new Employee { Id = 16, EmployeeName = "Alice16", EmployeeSalary = 10000 , EmployeeAge=23, ProfileImage="" }
            };

            if (employeeId == null) return result;
            else {

                var employeeFound = result.Find(e => e.Id == employeeId);
                if (employeeFound == null) return new List<Employee>();
                // return new List<Employee>() { new Employee() { EmployeeName = null, EmployeeAge = 0, EmployeeSalary = 0, Id = 0, ProfileImage = "" } };
                else
                    return new List<Employee>() { result.Find(e => e.Id == employeeId) };

            }

        }
    }
}
