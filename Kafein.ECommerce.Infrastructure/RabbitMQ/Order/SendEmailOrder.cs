using Diten.Daywork.Infrastructure.RabbitMQ.Order.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Diten.Daywork.Infrastructure.RabbitMQ.Order
{
    public class SendEmailOrder : IOrder
    {
        public string Id { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
	}
}
