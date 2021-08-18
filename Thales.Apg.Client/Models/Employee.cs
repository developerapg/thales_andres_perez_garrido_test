using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Apg.Client.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string Name { get; set; }

        [JsonProperty("employee_salary")]
        public Decimal Salary { get; set; }

        [JsonProperty("employee_age")]
        public int Age { get; set; }
        [JsonProperty("anualsalary")]
        public Decimal AnualSalary { get; set; }
        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }
    }

    public class DtoEmployees
    {
        [JsonProperty("data")]
        public Employee[] Employees { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class DtoEmployee
    {
        [JsonProperty("data")]
        public Employee Employees { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}