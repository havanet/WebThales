using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using System.Text.Json;


using Data.Model;

namespace Data.Access
{
    public class EmployeeApi
    {
        public readonly Uri BaseUrl;

        private string _urlEmployeeId;
        private string _urlEmployees;

        public readonly HttpClient _httpClient;
        public EmployeeApi(HttpClient httpClient, List<string> methods) {

            _httpClient = httpClient;
            _urlEmployees = methods[0];
            _urlEmployeeId = methods[1];
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            /// var response = await _httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");
             var response = await _httpClient.GetAsync(_urlEmployees);

            if (response.IsSuccessStatusCode)
            {
                string apiResult = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ApiEmployeeListResponse? objResp = JsonSerializer.Deserialize<ApiEmployeeListResponse>(apiResult, options);

                if (objResp.Status == "success") return objResp.Data ?? new List<Employee>(){};
            }
            throw new Exception("API Error Getting employees: " + response.ReasonPhrase);
        }


        //public async Task<List<Employee>> GetEmployeeByIdAsync1(int? _employeeId)
        //{
        //    var response = await _httpClient.GetAsync($"{_urlEmployeeId}{_employeeId}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string apiResult = await response.Content.ReadAsStringAsync();

        //        var options = new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true
        //        };
        //        ApiEmployeeListResponse? objResp = JsonSerializer.Deserialize<ApiEmployeeListResponse>(apiResult, options);

        //        if (objResp.Status == "success") return objResp.Data ?? new List<Employee>(){};            
        //    }
        //    throw new Exception("API Error Getting employees: "+ response.ReasonPhrase);
        //}

        public async Task<Employee> GetEmployeeByIdAsync(int? _employeeId)
        {
            if (_employeeId == null) return (new Employee());

            //var response = await _httpClient.GetAsync($"http://dummy.restapiexample.com/api/v1/employees/{_employeeId}");

            // string url = $"http://dummy.restapiexample.com/api/v1/employee/{_employeeId}";
            //string url = $"{_urlEmployeeId}{_employeeId}";

            var response = await _httpClient.GetAsync($"{_urlEmployeeId}{_employeeId}");


            if (response.IsSuccessStatusCode) 
            {
                string apiResult = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ApiEmployeeResponse? objResp = JsonSerializer.Deserialize<ApiEmployeeResponse>(apiResult, options);
                if (objResp.Status == "success") return objResp.Data ?? (new Employee());
            }

            throw new Exception("API Error getting employee: " + response.ReasonPhrase);
        }
    }
}
