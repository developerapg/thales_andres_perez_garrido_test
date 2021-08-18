using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Thales.Apg.Data.Interfaces;
using Thales.Apg.Entities.Dtos.Out;

namespace Thales.Apg.Data.Services.External
{
    public class ServiceEmployees : IServiceEmployees
    {
        private readonly IHttpClientFactory httpClient;
        private readonly ILogger<ServiceEmployees> logger;
        private readonly string uri = "/api/v1/employee";

        public ServiceEmployees(IHttpClientFactory _httpClient, ILogger<ServiceEmployees> _logger)
        {
            httpClient = _httpClient;
            logger = _logger;
        }

        public async Task<T> GetData<T>(int id) where T : BaseResponse
        {
            T result = (T)Activator.CreateInstance(typeof(T));

            try
            {
                var isSearchById = id > 0;
                var client = httpClient.CreateClient("Employees");

                var requestUri = isSearchById ? $"{uri}/{id}" : $"{uri}s";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode || id > 0)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    result = JsonSerializer.Deserialize<T>(content, options);
                }

                result.Message = result.Message ?? response.ReasonPhrase;
                result.Status = ((int)response.StatusCode).ToString();
                result.StatusCode = (int)response.StatusCode;


                client.Dispose();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }

            return result;
        }
    }
}
