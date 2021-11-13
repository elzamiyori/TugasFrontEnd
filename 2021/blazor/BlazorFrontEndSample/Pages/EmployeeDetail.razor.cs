using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;
using BlazorFrontEndSample.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEndSample.Pages
{
    public partial class EmployeeDetail
    {
       [Parameter]
        public string id { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeServices EmployeeServices {get; set;}
        public string Coordinate {get; set;}
        public string ButtonText {get; set;} =  "Hide Footer";


        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Employee = await EmployeeServices.GetById(Convert.ToInt32(id));
        }
    }
}