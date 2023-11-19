using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        public EmployeesController(ApplicationDbContext applicationDbContext)
        {
                _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            await _applicationDbContext.Database.OpenConnectionAsync();
            _applicationDbContext.EnableIdentityInsert("EmployeeDetails", true);
            var employee = new EmployeeDetails()
            {
                EmployeeId = addEmployeeRequest.EmployeeId,
                EmployeeName = addEmployeeRequest.EmployeeName,
                EmployeeAge = addEmployeeRequest.EmployeeAge,
                Email = addEmployeeRequest.Email,
                salary = addEmployeeRequest.salary,
                City = addEmployeeRequest.City,
                Street = addEmployeeRequest.Street, 
                Region = addEmployeeRequest.Region,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };
            await _applicationDbContext.EmployeeDetails.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            await _applicationDbContext.Database.CloseConnectionAsync();
            return RedirectToAction("Successful");

        }
        [HttpGet]
        public IActionResult Successful()
        {
            return View();
        }
        
    }
    
}
