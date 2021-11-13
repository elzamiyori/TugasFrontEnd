using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;

namespace BlazorFrontEndSample.Services
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
    }
}