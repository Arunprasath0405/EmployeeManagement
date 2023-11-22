using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Credentials
    {
        [Required]
        public string? Username { get; set; }
        [Key]
        public string? EmailId {  get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword {  get; set; }
    }
}
