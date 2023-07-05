namespace PocketDr.Api.DataTransferObjects
{
    public class MessageResponseDTO
    {
        public Guid MessageId { get; set; }

        public Guid ChatId { get; set; }

        public string Text { get; set; } = null!;

        public string Sender { get; set; } = null!;

        public string CreatedAt { get; set; }
    }
}
