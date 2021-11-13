using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;
using BlazorFrontEndSample.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEndSample.Pages
{
    public partial class EmployeePage
    {
         public IEnumerable<Employee> Employees { get; set; } 

        [Inject]
        public IEmployeeServices EmployeeServices {get; set;}
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeServices.GetAll()).ToList();
        }
    }
}