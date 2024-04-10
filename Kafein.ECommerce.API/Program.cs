using Diten.Daywork.Infrastructure.RabbitMQ.Consumers;
using Diten.Daywork.Infrastructure.RabbitMQ;
using Diten.Daywork.Infrastructure.RabbitMQ.Dtos;
using Diten.Daywork.Infrastructure.RabbitMQ.Producer;
using Diten.Daywork.Infrastructure.RabbitMQ.Services;
using Diten.Daywork.Infrastructure.RabbitMQ.Services.Interface;
using Kafein.ECommerce.Application;
using Kafein.ECommerce.Persistence;
using RabbitMQ.Client;
using Diten.Daywork.Infrastructure.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddPersistenceServices();

#region EventBus
builder.Services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
{
	var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
	var factory = new ConnectionFactory()
	{
		HostName = builder.Configuration["EventBus:HostName"]
	};
	if (!string.IsNullOrWhiteSpace(builder.Configuration["EventBus:UserName"]))
	{
		factory.UserName = builder.Configuration["EventBus:UserName"];
	}
	if (!string.IsNullOrWhiteSpace(builder.Configuration["EventBus:Password"]))
	{
		factory.Password = builder.Configuration["EventBus:Password"];
	}
	var retryCount = 5;
	if (!string.IsNullOrWhiteSpace(builder.Configuration["EventBus:RetryCount"]))
	{
		retryCount = int.Parse(builder.Configuration["EventBus:RetryCount"]);
	}
	return new DefaultRabbitMQPersistentConnection(factory, retryCount, logger);
});

builder.Services.AddSingleton<EventBusSendEmailConsumer>();
builder.Services.AddSingleton<EventBusRabbitMQProducer>();
#endregion

builder.Services.AddApplication();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kafein.ECommerce.API v1"));
}

app.UseRabbitListener();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
