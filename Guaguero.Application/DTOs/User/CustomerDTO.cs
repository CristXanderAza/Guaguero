
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Application.DTOs.User
{
    public class CustomerDTO 
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
