using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;

namespace BlazorFrontEndSample.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private HttpClient _httpClient;

        public EmployeeServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Employee> Add(Employee employee)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
           var results = await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/Employees");
           return results;
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return result;
        }

        public Task<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
