using Microsoft.Extensions.DependencyInjection;


namespace CXAD.NetStrategist
{
    public abstract class Strategist<C, K> : IStrategistFor<C, K> 
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<K, Type> _strategies;

        protected Strategist(IServiceProvider serviceProvider)
        {
            _strategies = new Dictionary<K, Type>();
            if (!typeof(C).IsInterface)
            {
                throw new InvalidOperationException("C debe ser una interfaz.");
            }
            _serviceProvider = serviceProvider;
        }

        protected void RegisterStrategy(K key, Type strategy)
        {
            if(!typeof(C).IsAssignableFrom(strategy))
            {
                throw new InvalidOperationException("El tipo de estrategia no es compatible con el tipo de interfaz.");
            }
            _strategies.Add(key, strategy);
        }

        public C GetStrategy(K key)
        {
            Type t = _strategies[key];
            return (C)_serviceProvider.GetRequiredService(t);
        }

        public IEnumerable<K> GetKeys()
            => _strategies.Keys;
    }
}
