using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Sindicatos;

namespace Guaguero.Domain.Entities.Users
{
    public class Employee : UserBase
    {
        public int SindicatoID { get; set; }
        public decimal Salary { get; set; }
        public virtual Sindicato Sindicato { get; set; }

        public Employee(string firstName, string lastName, string phoneNumber, Credential credential) : base(firstName, lastName, phoneNumber, credential)
        {
        }

        //public static Result<Employee> Create(string firstName, string lastName, string phoneNumber, string email, string password, int sindicatoID)
        //{
        //    var credential = Credential.Create(email, password);
        //    if (!credential.IsSuccessful)
        //        return Result<Employee>.Fail(credential.Message);
        //    return Result<Employee>.Success(new Employee(firstName, lastName, phoneNumber, credential.Data) { SindicatoID = sindicatoID });
        //}


        public static Result<Employee> Create(string firstName, string lastName, string phoneNumber, string email, string password, decimal salary, int sindicatoID)
        {
            var credential = Credential.Create(email, password);
            if (!credential.IsSuccessful)
                return Result<Employee>.Fail(credential.Message);
            return Result<Employee>.Success(new Employee(firstName, lastName, phoneNumber, credential.Data) { SindicatoID = sindicatoID, Salary = salary });
        }
    }
}
