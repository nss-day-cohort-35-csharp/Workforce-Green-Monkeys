using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GreenMonkeysMVC.Models.ViewModels
{
    public class EmployeeDetailsModel
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Computer Computer { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; }
    }
}
