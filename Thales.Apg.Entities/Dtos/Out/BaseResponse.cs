using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Thales.Apg.Entities.Dtos.Out
{
    public class BaseResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }
        
        [JsonIgnore]
        public int StatusCode { get; set; }
    }
}
