using System.Text.Json.Serialization;

namespace AnimalChat.Web.Models
{
    public class Session
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string SessionId { get; set; }

        public int? TokensUsed { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Message> Messages { get; set; }

        public Session(string name)
        {
            Id = Guid.NewGuid().ToString();
            Type = nameof(Session);
            SessionId = Id;
            TokensUsed = 0;
            Name = name;
            Messages = [];
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }

        public void UpdateMessage(Message message)
        {
            var match = Messages.Single(m => m.Id == message.Id);
            var index = Messages.IndexOf(match);
            Messages[index] = message;
        }
    }
}
