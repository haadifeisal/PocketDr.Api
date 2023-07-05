using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketDr.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    chatId = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Chat_pkey", x => x.chatId);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    messageId = table.Column<Guid>(type: "uuid", nullable: false),
                    chatId = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying", nullable: false),
                    sender = table.Column<string>(type: "character varying", nullable: false),
                    createdAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Message_pkey", x => x.messageId);
                    table.ForeignKey(
                        name: "Message",
                        column: x => x.chatId,
                        principalTable: "Chat",
                        principalColumn: "chatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_chatId",
                table: "Message",
                column: "chatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Chat");
        }
    }
}
