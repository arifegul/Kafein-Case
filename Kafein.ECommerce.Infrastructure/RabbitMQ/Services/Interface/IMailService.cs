using Diten.Daywork.Infrastructure.RabbitMQ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diten.Daywork.Infrastructure.RabbitMQ.Services.Interface
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
