using System.Text.Json.Serialization;
using Thales.Apg.Entities.Base;

namespace Thales.Apg.Entities.Dtos.Out
{
    public class DtoEmployeeById : BaseResponse
    {
        [JsonPropertyName("data")]
        public Employee Employee { get; set; }
    }
}
