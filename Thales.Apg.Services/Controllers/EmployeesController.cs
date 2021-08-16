using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Thales.Apg.Business.Interfaces;
using Thales.Apg.Entities.Dtos.Out;

namespace Thales.Apg.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IAppEmployee appEmployee;
        public EmployeesController(IAppEmployee _appEmployee)
        {
            appEmployee = _appEmployee;
        }

        [HttpGet]
        [Route("getall")]
        public DtoAllEmployees GetAll()
        {
            var result = appEmployee.GetAllEmployees();
            Response.StatusCode = result.StatusCode;
            return result;
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public DtoEmployeeById GetById(int id)
        {
            var result = appEmployee.GetEmployeeById(id);
            Response.StatusCode = result.StatusCode;
            return result;
        }
    }
}
