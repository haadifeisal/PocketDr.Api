namespace PocketDr.Api.Repositories.PocketDr.Models;

public partial class Message
{
    public Guid MessageId { get; set; }

    public Guid ChatId { get; set; }

    public string Text { get; set; } = null!;

    public string Sender { get; set; } = null!;

    public string CreatedAt { get; set; }

    public virtual Chat Chat { get; set; } = null!;
}
