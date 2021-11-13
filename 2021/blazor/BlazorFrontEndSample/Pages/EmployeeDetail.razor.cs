using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFrontEndSample.Models;
using BlazorFrontEndSample.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorFrontEndSample.Pages
{
    public partial class EmployeeDetail
    {
       [Parameter]
        public string id { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeServices EmployeeServices {get; set;}
        public string Coordinates {get; set;}
        public string ButtonText {get; set;} =  "Hide Footer";
        public string CssClass {get; set;} = null;
        protected void Button_Click(){
            if(ButtonText == "HideFooter"){
                CssClass = "HideFooter";
                ButtonText = "Show Footer";
                
            }
            else{
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
        protected void Mouse_Move(MouseEventArgs e){
            Coordinates = $"X = {e.ClientX}, Y = {e.ClientY}";
        }

        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Employee = await EmployeeServices.GetById(Convert.ToInt32(id));
        }
    }
}