using Guaguero.Application.DTOs.User;
using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Users;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Users;
using MediatR;

namespace Guaguero.Application.Commands.Users
{
    public class RegisterCustomerCommand : RegisterUserBaseCommand, IRequest<Result<CustomerDTO>>
    {
    }
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Result<CustomerDTO>>
    {
        private ICustomerRepository customerRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<Result<CustomerDTO>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            Result<Customer> result = Customer.Create(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.Password);

            if(!result.IsSuccessful)
            {
                return Result<CustomerDTO>.Fail(result.Message);
            }
            else
            {
                Customer customer = result.Data;
                customerRepository.Save(customer);
                return Result<CustomerDTO>.Success(new CustomerDTO
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email
                });
            }
        }
    }
}
