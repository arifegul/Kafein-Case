using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diten.Daywork.Infrastructure.RabbitMQ.Order.Interface
{
    public abstract class IOrder
    {
        public Guid RequestId { get; private init; }
        public DateTime CreationDate { get; private init; }

        public IOrder()
        {
            RequestId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
