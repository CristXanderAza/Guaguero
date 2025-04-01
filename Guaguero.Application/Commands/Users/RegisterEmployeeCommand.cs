

using Guaguero.Application.DTOs.User;
using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Users;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Users;
using MediatR;

namespace Guaguero.Application.Commands.Users
{
    public class RegisterEmployeeCommand : RegisterUserBaseCommand, IRequest<Result<EmployeeDTO>>
    {
    }
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, Result<EmployeeDTO>>
    {
        private IUserRepository userRepository;

        public RegisterEmployeeCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<Result<EmployeeDTO>> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            Result<Employee> result = Employee.Create(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.Password,  request.Salary, request.SindicatoID);

            if (!result.IsSuccessful)
            {
                return Result<EmployeeDTO>.Fail(result.Message);
            }
            else
            {
                Employee employee = result.Data;
                userRepository.Save(employee);
                return Result<EmployeeDTO>.Success(new EmployeeDTO
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    Salary = request.Salary,
                    SindicatoID = request.SindicatoID

                });
            }
        }
    }
}
