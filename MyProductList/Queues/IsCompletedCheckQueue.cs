using MyProductList.Dto.Dtos;
using System.Threading.Channels;

namespace MyProductList.Queues
{
    public class IsCompletedCheckQueue : IBackgroundTaskQueue<ShopListDto>
    {
        private readonly Channel<ShopListDto> queue;

        public IsCompletedCheckQueue(IConfiguration configuration)
        {
            int.TryParse(configuration["QueueCapacity"], out int capacity);

            BoundedChannelOptions options = new(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };

            queue = Channel.CreateBounded<ShopListDto>(options);
        }
        public async Task AddQueue(ShopListDto workItem)
        {
            ArgumentNullException.ThrowIfNull(workItem);

            await queue.Writer.WriteAsync(workItem);
        }

        public ValueTask<ShopListDto> Dequeue(CancellationToken cancellationToken)
        {
            var workItem = queue.Reader.ReadAsync(cancellationToken);

            return workItem;
        }
    }
}
