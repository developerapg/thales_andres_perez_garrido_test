using System.Threading.Tasks;
using Thales.Apg.Entities.Dtos.Out;

namespace Thales.Apg.Data.Interfaces
{
    public interface IServiceEmployees
    {
        Task<T> GetData<T>(int id) where T : BaseResponse;
    }
}
