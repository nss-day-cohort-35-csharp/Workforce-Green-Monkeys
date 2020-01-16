using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenMonkeysMVC.Models.ViewModels
{
    public class TrainingProgramDetailViewModel
    {
        public List<Employee> EmployeesInTraining { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
       
    }
}
