

using Guaguero.Domain.Entities.Users;

namespace Guaguero.Application.DTOs.User
{
    public class EmployeeDTO 
    {
        public Guid UserID { get; set; }
        public int SindicatoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }
}
