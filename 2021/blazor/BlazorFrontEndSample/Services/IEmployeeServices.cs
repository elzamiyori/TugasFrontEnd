using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;

namespace BlazorFrontEndSample.Services
{
    public interface IEmployeeServices
    {
          Task<IEnumerable<Employee>> GetAll();
          Task<Employee> GetById(int id);
    }
}