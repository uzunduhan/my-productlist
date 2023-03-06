namespace MyProductList.Queues
{
    public interface IBackgroundTaskQueue<T>
    {
        Task AddQueue(T workItem);
        ValueTask<T> Dequeue(CancellationToken cancellationToken);
    }
}
