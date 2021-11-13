using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latihan.Models;

namespace Latihan.Pages
{
    public partial class EmployeePage
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees(){
            Employee e1 = new Employee{
                EmployeeID=1,
                FirstName="Elza",
                LastName="Miyori",
                Email="elzamiyori@gmail.com",
                DateofBirth = new DateTime(2000,8,7),
                Gender = Gender.Female,
                Department = new Department{DepartmentID=2, DepartmentName="IT"},
                PhotoPath = "images/Elza.jpg"
            };

            Employee e2 = new Employee{
                EmployeeID=1,
                FirstName="Shely",
                LastName="Gigi",
                Email="shely@gmail.com",
                DateofBirth = new DateTime(1995,2,7),
                Gender = Gender.Female,
                Department = new Department{DepartmentID=2, DepartmentName="IT"},
                PhotoPath = "images/Shely.png"
            };

            Employee e3 = new Employee{
                EmployeeID=1,
                FirstName="Reksi",
                LastName="Bima",
                Email="reksi@gmail.com",
                DateofBirth = new DateTime(1997,5,1),
                Gender = Gender.Male,
                Department = new Department{DepartmentID=2, DepartmentName="IT"},
                PhotoPath = "images/reksi.png"
            };

            Employees = new List<Employee>{e1,e2,e3};
        }
    }
}