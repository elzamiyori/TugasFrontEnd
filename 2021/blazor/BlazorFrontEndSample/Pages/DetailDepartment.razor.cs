using System.Threading.Tasks;
using BlazorFrontEndSample.Models;
using BlazorFrontEndSample.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEndSample.Pages
{
    public partial class DetailDepartment
    {
        [Parameter]
        public string id { get; set; }

        [Inject]
        public IDepartmentServices DepartmentServices {get; set;}
        public Department Department { get; set; } = new Department();

        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Department = await DepartmentServices.GetById(int.Parse(id));
        }
    }
}