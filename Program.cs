using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using Confluent.Kafka;
using System.Net;
namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var lfu = new LFU<int, int>(2);
            lfu.put(1, 1);
            lfu.put(2, 2);
            Console.WriteLine(lfu.Get(1));
            lfu.put(3, 3);
            Console.WriteLine(lfu.Get(2));
            Console.WriteLine(lfu.Get(3));
            lfu.put(4, 4);
            Console.WriteLine(lfu.Get(1));
            Console.WriteLine(lfu.Get(3));
            Console.WriteLine(lfu.Get(4));
            Console.WriteLine(lfu.Get(4));
            */
            var config = new ProducerConfig
            {
                BootstrapServers = "0.0.0.0:49153",
                ClientId = Dns.GetHostName(),
            };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                producer.Flush();
                var t = producer.ProduceAsync("topic", new Message<Null, string> { Value = "hello world" });
                t.ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine("Failed!");
                    }
                    else
                    {
                        Console.WriteLine($"Wrote to offset: {task.Result.Offset}");
                    }
                });
            }
            var config2 = new ConsumerConfig
            {
                BootstrapServers = "0.0.0.0:49153",
                GroupId = Dns.GetHostName(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config2).Build())
            {
                consumer.Subscribe("topic");
                var i = 0;
                while (i < 5)
                {
                    var consumeResult = consumer.Consume();
                    Console.WriteLine(consumeResult.Message.Value);
                }

                consumer.Close();
            }
        }
    }
}
