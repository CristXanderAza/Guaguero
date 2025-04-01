using Guaguero.Domain.Entities.Users;

namespace Guaguero.Application.Commands.Users
{
    public abstract class RegisterUserBaseCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int SindicatoID { get; set; }
        public decimal Salary { get; set; }
    }
}
