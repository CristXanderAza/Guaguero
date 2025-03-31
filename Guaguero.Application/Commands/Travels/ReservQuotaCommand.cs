using CXAD.NetStrategist;
using Guaguero.Application.Commands.Travels.PaymentStrategies;
using Guaguero.Application.NotifInterfaces;
using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Entities.Travels.Payments;
using Guaguero.Domain.Entities.Users;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Users;
using MediatR;

namespace Guaguero.Application.Commands.Travels
{
    public class ReservQuotaCommand : IRequest<Result<Unit>>
    {
        public Guid TravelID { get; set; }
        public Guid CustomerID { get; set; }
        public int EntryStep { get; set; }
        public int SeatsQuantity { get; set; }
        public string PaymentType { get; set; }
        public string ConnectionID { get; set; }
    }

    public class ReservQuotaCommandHandler : IRequestHandler<ReservQuotaCommand, Result<Unit>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IQuotaRepository _quotaRepository;
        private readonly IInMemoryCache<Travel, Guid> _travelCache;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITravelNotificator _travelNotificator;
        private readonly IStrategistFor<IPayStrategy, string> _paymentStrategiest;

        public ReservQuotaCommandHandler(ITravelRepository travelRepository, IInMemoryCache<Travel, Guid> travelCache, ITravelNotificator travelNotificator
            , IStrategistFor<IPayStrategy, string> paymentStrategiest, ICustomerRepository customerRepository, IQuotaRepository quotaRepository)
        {
            _travelRepository = travelRepository;
            _travelCache = travelCache;
            _travelNotificator = travelNotificator;
            _paymentStrategiest = paymentStrategiest;
            _customerRepository = customerRepository;
            _quotaRepository = quotaRepository;
        }

        public async Task<Result<Unit>> Handle(ReservQuotaCommand request, CancellationToken cancellationToken)
        {
            Travel travel = await _getTravel(request.TravelID);
            if (travel == null)
                return Result<Unit>.Fail("El viaje seleccionado no existe");
            if (travel.Status == TravelState.Finished)
                return Result<Unit>.Fail("El viaje seleccionado ya ha concluido");
            if (travel.ActualStep > request.EntryStep)
                return Result<Unit>.Fail("El viaje ya ha pasado la parada seleccionada");
            if(travel.SeetsDisponibles < request.SeatsQuantity)
                return Result<Unit>.Fail("El viaje no posee asientos disponibles suficientes");
            if(travel.TotalSteps < request.EntryStep)
                return Result<Unit>.Fail("La parada seleccionada no existe");

            Customer customer = await _customerRepository.FindById(request.CustomerID);
            if(customer == null)
                return Result<Unit>.Fail("El cliente no existe");

            IPayStrategy payStrategy = _paymentStrategiest.GetStrategy(request.PaymentType);
            Result<PaymentBase> paymentRes = await payStrategy.MakePay(travel, customer, request.SeatsQuantity);
            if(!paymentRes.IsSuccessful)
                return Result<Unit>.Fail(paymentRes.Message);

            Quota quota = new Quota
            {
                Travel = travel,
                Customer = customer,
                EntryStep = request.EntryStep,
                Payment = paymentRes.Data,
                Total = paymentRes.Data.Amount,
                Status = QuotaState.Pending
            };

            await _quotaRepository.Save(quota);
            await _travelNotificator.SuscribeToTravel(travel.TravelID, request.ConnectionID);
            return Result<Unit>.Success(Unit.Value);
        }

        private async Task<Travel> _getTravel(Guid travelID)
        {

            Travel travel = await _travelCache.FindById(travelID);
            if(travel == null)
                travel = await _travelRepository.FindById(travelID);
            return travel;
        }
    }
}
