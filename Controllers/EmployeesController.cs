using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext applicationDbContext;
        public EmployeesController(ApplicationDbContext applicationDbContext)
        {
                this.applicationDbContext = applicationDbContext;
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
            var employee = new EmployeeDetails()
            {
                EmployeeId = addEmployeeRequest.EmployeeId,
                EmployeeName = addEmployeeRequest.EmployeeName,
                EmployeeAge = addEmployeeRequest.EmployeeAge,
                Email = addEmployeeRequest.Email
            };
            await applicationDbContext.EmployeeDetails.AddAsync(employee);
            try
            {
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Successful");
            }
            catch (Exception ex)
            {
                applicationDbContext.SaveChanges();
                return RedirectToAction("Add");
            }
        }
    }
    
}
