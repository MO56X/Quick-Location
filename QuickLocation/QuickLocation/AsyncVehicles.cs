using System.Runtime.CompilerServices;

namespace QuickLocation
{
    public class AsyncVehicles<V>
    {

        readonly Lazy<Task<V>> instance;
    
        public AsyncVehicles(Func<V> factory)
        {
            instance = new Lazy<Task<V>>(() => Task.Run(factory));
        }

        public AsyncVehicles(Func<Task<V>> factory)
        {
            instance = new Lazy<Task<V>>(() => Task.Run(factory));
        }


        public TaskAwaiter<V> GetAwaiter() 
        { 
        
        return instance.Value.GetAwaiter();

        }

        public void start()
        {
            var unused = instance.Value;

        }

    }
}
