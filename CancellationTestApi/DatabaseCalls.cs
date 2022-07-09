using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CancellationTestApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CancellationTestApi
{
    public class DatabaseCalls
    {
        private readonly CancelTestDbContext _cancelTestDbContext;

        public DatabaseCalls(CancelTestDbContext cancelTestDbContext)
        {
            _cancelTestDbContext = cancelTestDbContext;
        }

        public async Task<IEnumerable<OrderDetails>> GetData(CancellationToken cancellationToken)
        {
            Console.Write("do Something");
            var orderDetailsList = await _cancelTestDbContext.OrderDetails.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
            return orderDetailsList;
        }

        public async Task SeedLargeData()
        {
            for (var i = 0; i < 4000; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    await _cancelTestDbContext.AddAsync(new OrderDetails
                    {
                        OrderNumber = $"ORD_{i}_{j}",
                        OrderDateTime = DateTimeOffset.UtcNow,
                        StoreName = $"STR_{i}_{j}",
                    }).ConfigureAwait(false);
                }
                await _cancelTestDbContext.SaveChangesAsync(CancellationToken.None);
            }
        }
    }
}
