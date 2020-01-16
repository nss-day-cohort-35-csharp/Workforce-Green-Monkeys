﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



namespace GreenMonkeysMVC.Models

{

    public class Department

    {

        public int Id { get; set; }

        [Display(Name = "Department Name")]

        public string Name { get; set; }

        public int Budget { get; set; }
        [Display(Name = "Size of Department")]
        public int EmployeeCount { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();

    }

}