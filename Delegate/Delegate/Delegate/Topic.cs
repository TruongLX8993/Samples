using System.Collections.Generic;

namespace Delegate
{
    public class Topic
    {
        public delegate void ReceiveMessage(Topic topic, string message);

        public delegate string Serialize(object message);

        public Serialize Serializer { get; set; }

        public event ReceiveMessage OnReceiveMessage;
        public string Name { get; }

        public Topic(string name)
        {
            Name = name;
        }

        public void SendMessage(object message)
        {
            OnReceiveMessage?.Invoke(this, Serializer == null ? message.ToString() : Serializer.Invoke(message));
        }
    }
}