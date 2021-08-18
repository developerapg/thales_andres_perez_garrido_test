using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thales.Apg.Client.Models
{
    public class ServiceEmployees
    {
        public static async Task<DtoEmployees> GetEmployees(int id = 0)
        {
            var isSearchById = id > 0;
            var result = new DtoEmployees();
            HttpClient service = new HttpClient();
            service.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseServiceEmployees"]);
            var uri = id > 0 ? $"/api/employees/getbyid/{id}" : "/api/employees/getall";
            var response = await service.GetAsync(uri).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync();

            if (isSearchById)
            {
                var temp = JsonConvert.DeserializeObject<DtoEmployee>(content);
                if (temp != null)
                {
                    result = new DtoEmployees { Message = temp.Message, Status = temp.Status, Employees = temp.Employees == null ? null : new Employee[] { temp.Employees } };
                }
            }
            else
            {
                result = JsonConvert.DeserializeObject<DtoEmployees>(content);
            }

            service.Dispose();
            return result;
        }
    }
}