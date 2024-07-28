using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Data.Model;
using Data.Access;
using System.Text.Json;


namespace WebThales.Services
{
    /*
   public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployeesAsync1()
        {
            var response = await _httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Employee>>();
            }

            throw new Exception("API Error Getting employees");
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var response = await _httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");

            if (response.IsSuccessStatusCode)
            {
                string apiResult = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ApiEmployeeListResponse objResp = JsonSerializer.Deserialize<ApiEmployeeListResponse>(apiResult, options);
                if(objResp.Status == "success") return objResp.Data;
                else return new List<Employee>();  // an empty list
               
            }

            throw new Exception("API Error Getting employees");
        }

        public async Task<Employee> GetEmployeeByIdAsync1(int _employeeId)
        {
            var response = await _httpClient.GetAsync($"http://dummy.restapiexample.com/api/v1/employee/{_employeeId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Employee>();
            }

            throw new Exception("API Error Getting employee");
        }

        public async Task<Employee> GetEmployeeByIdAsync(int _employeeId)
        {
            var response = await _httpClient.GetAsync($"http://dummy.restapiexample.com/api/v1/employees/{_employeeId}");

            if (response.IsSuccessStatusCode)
            {
                string apiResult = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ApiEmployeeResponse objResp = JsonSerializer.Deserialize<ApiEmployeeResponse>(apiResult, options);
                if (objResp.Status == "success") return objResp.Data;
                //else return new List<Employee>();  // an empty list
                return null;
            }

            throw new Exception("API Error Getting employees");
        }

        [HttpGet]
        public async Task<List<Employee>> GetDummyEmployees()
        {
            // dummy employee list 
          
                    var employees = new List<Employee> 
                    {
                        new Employee { Id = 1, EmployeeName = "Alice", EmployeeSalary = 5000, EmployeeAge = 30, ProfileImage = "" },
                        new Employee { Id = 2, EmployeeName = "Bob", EmployeeSalary = 6000, EmployeeAge = 40, ProfileImage = "https://example.com/images/bob.jpg" },
                        new Employee { Id = 3, EmployeeName = "Charlie", EmployeeSalary = 7000, EmployeeAge = 35, ProfileImage = "https://example.com/images/charlie.jpg" },
                        new Employee { Id = 3, EmployeeName = "Charlie", EmployeeSalary = 7000, EmployeeAge = 35, ProfileImage = "https://example.com/images/charlie.jpg" },
                    };

                    return employees;
        }
        [HttpGet]
        public async Task<List<Employee>> GetDummyByIdv2(int _employeeId)
        {
            // dummy employee
            var employee = new Employee
            {
                Id = 1,
                EmployeeName = "Alice",
                EmployeeSalary = 5000,
                EmployeeAge = 30,
                ProfileImage = ""
            };

            var selectedEmployee = new List<Employee> { employee };

            return selectedEmployee;
        }



        [HttpGet]
        public ActionResult<Employee> GetDummyById(int _employeeId)
        {
            // dummy employee
            var employee = new Employee
            {
                Id = 1,
                EmployeeName = "Alice",
                EmployeeSalary = 5000,
                EmployeeAge = 30,
                ProfileImage = "https://example.com/images/alice.jpg"
            };

            return employee;
        }

    }

    */
}





