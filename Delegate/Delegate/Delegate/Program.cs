using System;
using Newtonsoft.Json;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var topic = new Topic("Topic test")
            {
                Serializer = JsonConvert.SerializeObject
            };
            topic.OnReceiveMessage += (tp, msg) => { Console.WriteLine($"{topic.Name}:{msg}"); };
            topic.SendMessage(new
            {
                Name = "truonglx",
                DateTime = DateTime.Now
            });
            Console.ReadKey();
        }
    }
}