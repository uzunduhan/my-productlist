using MyProductList.Data.Models;
using MyProductList.Dto.Dtos;
using System.Threading.Channels;

namespace MyProductList.Queues
{
    public class IsCompletedCheckQueue : IBackgroundTaskQueue<ShopList>
    {
        private readonly Channel<ShopList> queue;

        public IsCompletedCheckQueue(IConfiguration configuration)
        {
            int.TryParse(configuration["QueueCapacity"], out int capacity);

            BoundedChannelOptions options = new(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };

            queue = Channel.CreateBounded<ShopList>(options);
        }
        public async Task AddQueue(ShopList workItem)
        {
            ArgumentNullException.ThrowIfNull(workItem);

            await queue.Writer.WriteAsync(workItem);
        }

        public ValueTask<ShopList> Dequeue(CancellationToken cancellationToken)
        {
            var workItem = queue.Reader.ReadAsync(cancellationToken);

            return workItem;
        }
    }
}
