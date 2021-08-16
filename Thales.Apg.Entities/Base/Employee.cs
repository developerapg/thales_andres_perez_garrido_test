using System;
using System.Text.Json.Serialization;

namespace Thales.Apg.Entities.Base
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string Name { get; set; }

        [JsonPropertyName("employee_salary")]
        public Decimal Salary { get; set; }

        [JsonPropertyName("employee_age")]
        public int Age { get; set; }

        public Decimal AnualSalary { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }
    }
}
