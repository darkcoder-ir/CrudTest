using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Entities.Events;
using MediatR;
using RabbitMQ.Client;

namespace Mc2.CrudTest.Core.Application.Customer.Event;
  internal class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
  {
    public CustomerCreatedEventHandler () { }

    public async Task Handle (CustomerCreatedEvent notification, CancellationToken cancellationToken)
      {
        var customerEvent = notification.Customer;
        var factory = new ConnectionFactory () { HostName = "localhost" };
        factory.UserName = ConnectionFactory.DefaultUser;
        factory.Password = ConnectionFactory.DefaultPass;
        factory.VirtualHost = ConnectionFactory.DefaultVHost;
        factory.HostName = "hostName";
        factory.Port = AmqpTcpEndpoint.UseDefaultPort;
        factory.MaxMessageSize = 512 * 1024 * 1024;
        // Create a connection to RabbitMQ
        using ( var connection = factory.CreateConnection () )
        {
          // Create a channel
          using ( var channel = connection.CreateModel () )
          {
            // Declare a queue
            channel.QueueDeclare (queue: "CustomerCreatedEvent",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            // Create a message
            string message = JsonSerializer.Serialize (customerEvent);
            var body = Encoding.UTF8.GetBytes (message);

            // Publish the message to the queue
            channel.QueueDeclare(queue: "CustomerCreated",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            channel.BasicPublish (exchange: "Customer",
                                  routingKey: "Create",
                                  basicProperties: null,
                                  body: body);
          }
        }
        await Task.CompletedTask.ConfigureAwait (false);
        //throw new NotImplementedException();
      }
  }
 