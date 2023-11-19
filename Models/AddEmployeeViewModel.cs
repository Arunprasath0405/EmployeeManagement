namespace EmployeeManagement.Models
{
    public class AddEmployeeViewModel
    {   
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string? Email { get; set; }
        public int salary { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
