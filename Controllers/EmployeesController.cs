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
        public ActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            try
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
            catch(Exception ex) {
                return RedirectToAction();
                    }

        }
        [HttpGet]
        public IActionResult Successful()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Credentials addcredentials)
        {
            await _applicationDbContext.Database.OpenConnectionAsync();
            var credentials = new Credentials()
            {
                Username = addcredentials.Username,
                EmailId = addcredentials.EmailId,
                Password = addcredentials.Password,
                ConfirmPassword = addcredentials.ConfirmPassword,
            };
            var employees = await _applicationDbContext.EmployeeDetails.ToListAsync();
            await _applicationDbContext.Credentials.AddAsync(credentials);
            await _applicationDbContext.SaveChangesAsync();
            await _applicationDbContext.Database.OpenConnectionAsync();

            return View("EmployeeDetails", employees);
        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginPage(Credentials credentials)
        {
            await _applicationDbContext.Database.OpenConnectionAsync();
            var user = await _applicationDbContext.Credentials.FirstOrDefaultAsync(u => u.Username == credentials.Username); 
            if(user!=null && user.Password == credentials.Password)
            {
                var employees = await _applicationDbContext.EmployeeDetails.ToListAsync();
                await _applicationDbContext.Database.CloseConnectionAsync();
                return View("EmployeeDetails", employees);
            }
            else
            {
                return View("Registration");
            }
        }

    }
    
}
