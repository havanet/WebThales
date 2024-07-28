using System.Text.Json.Serialization;

namespace Data.Model
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string? EmployeeName { get; set; }

        [JsonPropertyName("employee_salary")]
        public decimal EmployeeSalary { get; set; }

        [JsonPropertyName("employee_age")]
        public int EmployeeAge { get; set; }

        [JsonPropertyName("profile_image")]
        public string? ProfileImage { get; set; }

        public decimal Annualsalary { get{ return EmployeeSalary * 12; } }


    }

}
