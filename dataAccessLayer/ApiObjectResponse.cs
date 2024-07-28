using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Access
{
    /// <summary>
    /// Employee list response
    /// </summary>
    public class ApiEmployeeListResponse
    {
        public string? Status { get; set; }
        public List<Employee>? Data { get; set; }
        public string? Message { get; set; }
    }


    /// <summary>
    /// Employee response
    /// </summary>
    public class ApiEmployeeResponse
    {
        public string Status { get; set; }
        public Employee Data { get; set; }
        public string Message { get; set; }
    }


}
