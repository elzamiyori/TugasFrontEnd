using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;

namespace BlazorFrontEndSample.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private HttpClient _httpClient;
        public DepartmentServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            var results = await _httpClient.GetFromJsonAsync<IEnumerable<Department>>("api/Departments");
            return results;
        }

        public async Task<Department> GetById(int id)
        {
            var results = await _httpClient.GetFromJsonAsync<Department>($"api/Departments/{id}");
            return results;
        }
    }
}