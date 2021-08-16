using System.Threading.Tasks;
using Thales.Apg.Entities.Dtos.Out;

namespace Thales.Apg.Data.Interfaces
{
    public interface IServiceEmployees
    {
        Task<DtoAllEmployees> GetData(int id);
    }
}
