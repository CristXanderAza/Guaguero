using Guaguero.Domain.Base;

namespace Guaguero.Domain.Entities.Users
{
    public abstract class UserBase : AuditEntity
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Credential Credential { get; set; }
        public string Email => Credential.Email;
        protected UserBase(string firstName, string lastName, string phoneNumber,Credential credential)
        {
            UserID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Credential = credential;
        }

        public bool Authenticate(string password)
            => Credential.Authenticate(password);
    }
}

