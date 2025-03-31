using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Travels;

namespace Guaguero.Domain.Entities.Users
{
    public class Customer : UserBase
    {
        public virtual CreditPerUser Credit { get; set; }
        public virtual ICollection<Quota> Quotas { get; set; }
        public int? DiscountID { get; set; }
        public virtual Discount? Discount { get; set; }
        private Customer(string firstName, string lastName, string phoneNumber,  Credential credential) : 
            base(firstName, lastName, phoneNumber, credential)
        {
            
        }

        public static Result<Customer> Create(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            var credential = Credential.Create(email, password);
            if (!credential.IsSuccessful)
                return Result<Customer>.Fail(credential.Message);
            return Result<Customer>.Success(new Customer(firstName, lastName, phoneNumber, credential.Data));
        }
    }
}
