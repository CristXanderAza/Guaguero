﻿using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using MediatR;

namespace Guaguero.Application.Commands.Travels
{
    public class ConfirmArrivalCommand : IRequest<Result<Unit>>
    {
        public IEnumerable<Guid> ConfirmedArrivals { get; set; }
        public Guid TravelId { get; set; }
        public int StepIndex { get; set; }
    }

    public class ConfirmedArrangeCommandHandler : IRequestHandler<ConfirmArrivalCommand, Result<Unit>>
    {
        private readonly IQuotaRepository _quotaRepository;

        public async Task<Result<Unit>> Handle(ConfirmArrivalCommand request, CancellationToken cancellationToken)
        {
            var quotas = await _quotaRepository.GetQuotaOfTravelInStep(request.TravelId, request.StepIndex);
            foreach(var quota in quotas)
            {
                if (request.ConfirmedArrivals.Contains(quota.QuotaID))
                {
                    quota.Status = QuotaState.Arrived;
                    await _quotaRepository.Update(quota);
                }
                else
                {
                    quota.Status = QuotaState.Canceled;
                    await _quotaRepository.Update(quota);
                }
            }
            return Result<Unit>.Success(Unit.Value);
            //throw new NotImplementedException();
        }
    }
}
