using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GreenMonkeysMVC.Models.ViewModels
{
    public class EmployeeCreateModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Computers { get; set; }
    }
}
