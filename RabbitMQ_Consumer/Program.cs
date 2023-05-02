using RabbitMQ;

using RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://svnwklcy:BIqAmhaOvIpke8pI7ntccKUbzX_xuYBD@shark.rmq.cloudamqp.com/svnwklcy");

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "queue", durable: false, exclusive: false, autoDelete: true);

        EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(channel);
        channel.BasicConsume(queue: "queue", autoAck: true, consumer: eventingBasicConsumer);
        eventingBasicConsumer.Received += (sender, e) =>
        {
            var data = Encoding.UTF8.GetString(e.Body.Span);
            Console.WriteLine(data);
        };
    }
}
Console.ReadLine();