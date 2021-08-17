using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Thales.Apg.Client.Models;

namespace Thales.Apg.Client.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetEmployees(int id = 0)
        {
            var data = await ServiceEmployees.GetEmployees(id);
            return View("_ResultEmployees", data);
        }
    }
}