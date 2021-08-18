using System.Text.Json.Serialization;
using Thales.Apg.Entities.Base;

namespace Thales.Apg.Entities.Dtos.Out
{
    public class DtoAllEmployees : BaseResponse
    {
        [JsonPropertyName("data")]
        public Employee[] Employees { get; set; }
    }
}
