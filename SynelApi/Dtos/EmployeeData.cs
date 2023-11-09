namespace SynelApi.Dtos
{
    public class EmployeeData
    {
        public string PayrollNumber { get; set; } = string.Empty;
        public string Forename { get; set; } = string.Empty;
        public string Surename { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
    }
}
