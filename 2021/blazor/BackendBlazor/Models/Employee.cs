using System;

namespace BackendBlazor.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public DateTime DateofBirth {get; set;}
        public Gender Gender {get; set;}
        public Department Department { get; set; }
        public string PhotoPath { get; set; }

    }

    public enum Gender {
        Male,Female
    }
}