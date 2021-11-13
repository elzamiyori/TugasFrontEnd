using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var newEmployee = await _appDbContext.Employees.AddAsync(employee);
            try
            {
                 await _appDbContext.SaveChangesAsync();
                 return newEmployee.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await GetEmployee(employeeId);
            if(result!=null){
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await _appDbContext.Employees.Include(e=>e.Department)
            .FirstOrDefaultAsync(e=>e.EmployeeId==employeeId);

            if(result!=null){
                return result;
            }else {
                throw new Exception($"Error: Data Tidak Ditemukan");
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.Include(e=>e.Department).ToListAsync();
        }

        //menambahkan search employee
        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;
            if(!string.IsNullOrEmpty(name)){
                query = query.Where(e=>e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if(gender!=null){
                query = query.Where(e=>e.Gender==gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await GetEmployee(employee.EmployeeId);
            if(result!=null){
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}