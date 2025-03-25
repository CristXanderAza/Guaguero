

namespace CXAD.NetStrategist
{
    public interface IStrategistFor<C, K> 
    {
        C GetStrategy(K key);
        IEnumerable<K> GetKeys();
    }
}
