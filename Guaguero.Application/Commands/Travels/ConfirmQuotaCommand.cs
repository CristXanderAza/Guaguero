using Guaguero.Application.DTOs.Travel;
using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using MediatR;

namespace Guaguero.Application.Commands.Travels
{
    public class ConfirmQuotaCommand : IRequest<Result<ArrivalDTO>>
    {
        public Guid QuotaID { get; set; }
        public Guid TravelID { get; set; }
    }

    public class ConfirmQuotaCommandHandler : IRequestHandler<ConfirmQuotaCommand, Result<ArrivalDTO>> 
     {
        private readonly ITravelRepository _travelRepository;
        private readonly IQuotaRepository _quotaRepository;
        private readonly IMediator _mediator;
        public ConfirmQuotaCommandHandler(ITravelRepository travelRepository, IMediator mediator, IQuotaRepository quotaRepository)
        {
            _travelRepository = travelRepository;
            _quotaRepository = quotaRepository;
            _mediator = mediator;
        }
        public async Task<Result<ArrivalDTO>> Handle(ConfirmQuotaCommand request, CancellationToken cancellationToken)
        {
            var quota = await _quotaRepository.FindById(request.QuotaID);
            Travel travel = await _travelRepository.FindById(request.TravelID);
            if (quota == null)
            {
                return Result<ArrivalDTO>.Fail("Reserva no existente");
            }
            if (quota.TravelID != request.TravelID)
            {
                return Result<ArrivalDTO>.Fail("Reserva no existente");
            }
            if (quota.Status == QuotaState.Confirmed)
            {
                return Result<ArrivalDTO>.Fail("Reserva no existen");
            }
            if(travel.StepState != StepState.Yellow)
            {
                return Result<ArrivalDTO>.Fail("No se puede confirmar la reserva en este momento");
            }

            quota.Status = QuotaState.Confirmed;
            await _quotaRepository.Update(quota);
            //var travel = await _travelRepository.FindById(request.TravelID);
            //var quotas = await _travelRepository.GetQuotas(request.TravelID);
            return Result<ArrivalDTO>.Success(new ArrivalDTO
            {
                Id = quota.QuotaID,
                seets = quota.Quantity,
                TravelID = quota.TravelID,
                Total = quota.Total,
                IsPaid = quota.Payment.Accepted
            });
        }
    }
}
