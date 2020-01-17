using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using GreenMonkeysMVC.Data;
using GreenMonkeysMVC.Models;
using GreenMonkeysMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GreenMonkeysMVC.Controllers
{
    public class EmployeesController : Controller
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                // "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DepartmentsEmployees;Integrated Security=True";
                string _connectionString = "Server=localhost\\SQLEXPRESS;Database=BangazonWorkforce;Trusted_Connection=True;";
                return new SqlConnection(_connectionString);
            }
        }
        // GET: Employees
        public ActionResult Index()
        {
         
            EmployeeRepository employeeRepo = new EmployeeRepository();
            List<Employee> allEmployeesWithDepartments = employeeRepo.GetAllEmployeesWithDepartment();
        
            return View(allEmployeesWithDepartments);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            var employee = employeeRepo.GetEmployeeById(id);
            DepartmentRepository departmentRepo = new DepartmentRepository();
            var department = departmentRepo.GetDepartmentById(employee.DepartmentId);
            ComputerRepository computerRepo = new ComputerRepository();
            var computer = computerRepo.GetComputerById(employee.ComputerId);
            TrainingProgramRepository trainingProgramRepo = new TrainingProgramRepository();
            List<TrainingProgram> trainingPrograms = trainingProgramRepo.GetTrainingProgramsByEmployeeId(id);

            var viewModel = new EmployeeDetailsModel()
            {
                Employee = employee,
                Department = department,
                Computer = computer,
                TrainingPrograms = trainingPrograms
            };

            return View(viewModel);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            DepartmentRepository departmentRepo = new DepartmentRepository();
            var departments = departmentRepo.GetAllDepartments().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            ComputerRepository computerRepo = new ComputerRepository();
            var computers = computerRepo.GetAvailableComputers().Select(d => new SelectListItem
            {
                Text = $"{d.Make} {d.Model}",
                Value = d.Id.ToString()
            }).ToList();


            var viewModel = new EmployeeCreateModel()
            {
                Employee = new Employee(),
                Departments = departments,
                Computers = computers
            };

            return View(viewModel);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Employee (FirstName, LastName, DepartmentId, Email, IsSupervisor, ComputerId)
                                            VALUES (@firstName, @lastName, @departmentId, @email, @isSupervisor, @computerId)";

                        cmd.Parameters.Add(new SqlParameter("@firstName", employee.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@lastName", employee.LastName));
                        cmd.Parameters.Add(new SqlParameter("@departmentId", employee.DepartmentId));
                        cmd.Parameters.Add(new SqlParameter("@email","example@gmail.com"));
                        cmd.Parameters.Add(new SqlParameter("@isSupervisor", employee.IsSupervisor));
                        cmd.Parameters.Add(new SqlParameter("@computerId", employee.ComputerId));

                        cmd.ExecuteNonQuery();
                    }
                }

                // RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentRepository departmentRepo = new DepartmentRepository();
            var departments = departmentRepo.GetAllDepartments().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            ComputerRepository computerRepo = new ComputerRepository();
            var computers = computerRepo.GetAvailableComputers().Select(d => new SelectListItem
            {
                Text = $"{d.Make} {d.Model}",
                Value = d.Id.ToString()
            }).ToList();

            EmployeeRepository employeeRepo = new EmployeeRepository();
            var employee = employeeRepo.GetEmployeeById(id);

             var viewModel = new EmployeeCreateModel()
             {
                  Employee = employee,
                  Departments = departments,
                  Computers = computers
             };
             return View(viewModel);
        }


        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                EmployeeRepository employeeRepo = new EmployeeRepository();
                employeeRepo.UpdateEmployee(id, employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}