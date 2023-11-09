using System.ComponentModel.DataAnnotations;

namespace SynelApi.Entities
{
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Payroll number is required")]
        public string PayrollNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Forename is required")]
        public string Forename { get; set; } = string.Empty;
        [Required(ErrorMessage = "Surname is required")]
        public string Surename { get; set; } = string.Empty;
        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        public string Telephone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address 2 is required")]
        public string Address2 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Postcode is required")]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailHome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
    }
}
