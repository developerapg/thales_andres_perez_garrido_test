using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thales.Apg.Entities.Dtos.Out;

namespace Thales.Apg.Business.Interfaces
{
    public interface IAppEmployee
    {
        DtoAllEmployees GetAllEmployees();

        DtoEmployeeById GetEmployeeById(int id);
    }
}
