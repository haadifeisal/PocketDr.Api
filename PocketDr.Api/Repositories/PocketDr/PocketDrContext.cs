using Microsoft.EntityFrameworkCore;
using PocketDr.Api.Repositories.PocketDr.Models;

namespace PocketDr.Api.Repositories.PocketDr;

public partial class PocketDrContext : DbContext
{
    public PocketDrContext()
    {
    }

    public PocketDrContext(DbContextOptions<PocketDrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("Chat_pkey");

            entity.ToTable("Chat");

            entity.Property(e => e.ChatId)
                .ValueGeneratedNever()
                .HasColumnName("chatId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("Message_pkey");

            entity.ToTable("Message");

            entity.HasIndex(e => e.ChatId, "IX_Message_chatId");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("messageId");
            entity.Property(e => e.ChatId).HasColumnName("chatId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Text)
                .HasColumnType("character varying")
                .HasColumnName("text");
            entity.Property(e => e.Sender)
                .HasColumnType("character varying")
                .HasColumnName("sender");

            entity.HasOne(d => d.Chat).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ChatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Message");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
