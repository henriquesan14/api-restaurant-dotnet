namespace Restaurant.Core.Services
{
    public interface IMessageBusService
    {
        void Publish(string queue, object message); 
    }
}
