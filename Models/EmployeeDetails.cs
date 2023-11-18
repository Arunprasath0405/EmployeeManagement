using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string? Email {  get; set; }
    }
}
