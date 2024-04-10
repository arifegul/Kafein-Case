using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diten.Daywork.Infrastructure.RabbitMQ
{
    public interface IRabbitMQPersistentConnection : IDisposable
    {
        //anlık olarak connectionımızın durumunu gösteren property
        bool IsConnected { get; }

        //connect olma metodu
        bool TryConnect();

        IModel CreateModel();
    }
}
