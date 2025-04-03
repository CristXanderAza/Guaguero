using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
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
        private readonly ITravelRepository _travelRepository;
        private readonly IInMemoryCache<Travel,Guid> _cache;

        public ConfirmedArrangeCommandHandler(IQuotaRepository quotaRepository, ITravelRepository travelRepository, IInMemoryCache<Travel, Guid> cache)
        {
            _quotaRepository = quotaRepository;
            _travelRepository = travelRepository;
            _cache = cache;
        }

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
                    var tr = await getTravel(request.TravelId);
                    tr.SeetsOcupied -= quota.Quantity;
                    await _quotaRepository.Update(quota);
                    await _travelRepository.Update(tr);
                }
            }
            return Result<Unit>.Success(Unit.Value);
            //throw new NotImplementedException();
        }

        private async Task<Travel> getTravel(Guid guid)
        {
            var tr =  await _cache.FindById(guid);
            if(tr == null)
            {
                tr = await _travelRepository.FindById(guid);
            }
            return tr;
        }
    }
}
