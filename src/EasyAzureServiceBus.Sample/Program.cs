﻿namespace EasyAzureServiceBus.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            // Create a bus instance.
            IBus bus = AzureCloud.CreateBus();

            // Subscribe to messages.
            var autoSubscriber = new AutoSubscriber(bus, "Consumer");
            autoSubscriber.Subscribe(Assembly.GetExecutingAssembly());

            // Send 100 messages.
            for (int i = 0; i < 100; i++)
            {
                bus.Publish(new SampleMessage(i.ToString()));
            }

            Console.ReadKey();
        }
    }
}