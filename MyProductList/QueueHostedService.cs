using AutoMapper;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MyProductList.Dto.Dtos;
using MyProductList.Queues;

namespace MyProductList
{
    public class QueueHostedService : BackgroundService
    {
        private readonly IBackgroundTaskQueue<ShopListDto> queue;
        private readonly IMapper mapper;
        private readonly IShopListMongoService shopListMongoService;

        public QueueHostedService(IBackgroundTaskQueue<ShopListDto> queue, IMapper mapper, IServiceScopeFactory factory)
        {
            this.queue = queue;
             shopListMongoService = factory.CreateScope().ServiceProvider.GetRequiredService<IShopListMongoService>();
            this.mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var name = await queue.Dequeue(stoppingToken);
                await Task.Delay(1000);

                ShopListMongo dto = mapper.Map<ShopListMongo>(name);

                shopListMongoService.Create(dto);


            }
        }
    }
}
