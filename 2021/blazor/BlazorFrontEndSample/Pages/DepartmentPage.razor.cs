using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;
using BlazorFrontEndSample.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEndSample.Pages
{
    public partial class DepartmentPage
    {
        public List<Department> Departments { get; set; } = new List<Department>();

        [Inject]
        public IDepartmentServices DepartmentServices {get; set;}
        protected override async Task OnInitializedAsync()
        {
            Departments = (await DepartmentServices.GetAll()).ToList();
        }
    }
}