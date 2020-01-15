using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using GreenMonkeysMVC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenMonkeysMVC.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Number of Employees")]
        public int? EmployeeNumber { get; set; }

    }
}