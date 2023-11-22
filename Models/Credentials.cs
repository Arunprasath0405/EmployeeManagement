using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    public class Credentials
    {
        public string? Username { get; set; }
        public string? EmailId {  get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword {  get; set; }
    }
}
