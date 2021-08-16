using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thales.Apg.Business.Interfaces;
using Thales.Apg.Data.Interfaces;
using Thales.Apg.Entities.Base;
using Thales.Apg.Entities.Dtos.Out;

namespace Thales.Apg.Business
{
    public class AppEmployee : IAppEmployee
    {
        private readonly IServiceEmployees service;
        private DtoAllEmployees data;

        public AppEmployee(IServiceEmployees _service)
        {
            service = _service;
        }
        public DtoAllEmployees GetAllEmployees()
        {
            GetRecords();
            return data;
        }

        public DtoEmployeeById GetEmployeeById(int id)
        {
            GetRecords(id);

            var result = new DtoEmployeeById
            {
                Message = data.Message,
                Status = data.Status,
                StatusCode = data.StatusCode,
                Employee = data.Employees != null ? data.Employees.FirstOrDefault() : null
            };

            return result;
        }

        private void GetRecords(int id = 0)
        {
            var result = service.GetData(id);
            data = result.Result;
            data.Employees = CalculateAnualSalary(data.Employees);
        }

        private Employee[] CalculateAnualSalary(Employee[] data)
        {
            if (data != null)
            {
                foreach (var item in data)
                {
                    item.AnualSalary = item.Salary * 12;
                }
            }

            return data;
        }
    }
}
