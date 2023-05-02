using RabbitMQ;
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://svnwklcy:BIqAmhaOvIpke8pI7ntccKUbzX_xuYBD@shark.rmq.cloudamqp.com/svnwklcy");

using(var connection = factory.CreateConnection())
{
    using(var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "queue", durable: false, exclusive: false, autoDelete: true);

        var byteData = Encoding.UTF8.GetBytes("JFLSKJFLSJLDFSKJ SLKJFLSKFJ SFSF");
       for(int i = 0; i < 100; i++)
        {
            channel.BasicPublish(exchange: "", routingKey: "queue", body: byteData);
            Console.WriteLine("sent");
        }
    }
}