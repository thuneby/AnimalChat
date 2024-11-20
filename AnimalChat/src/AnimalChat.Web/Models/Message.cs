namespace AnimalChat.Web.Models
{
    public class Message(string sessionId, string sender, int? tokens, string text)
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Type { get; set; } = nameof(Message);

        public string SessionId { get; set; } = sessionId;

        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        public string Sender { get; set; } = sender;

        public int? Tokens { get; set; } = tokens;

        public string Text { get; set; } = text;
    }
}
