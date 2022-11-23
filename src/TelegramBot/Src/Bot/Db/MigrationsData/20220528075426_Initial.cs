using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BotApplication.Bot.Db.MigrationsData
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bot");

            migrationBuilder.CreateTable(
                name: "chats",
                schema: "bot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SoftDelete = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true),
                    StateData = table.Column<string>(type: "text", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "bot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SoftDelete = table.Column<bool>(type: "boolean", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    TelegramFirstname = table.Column<string>(type: "text", nullable: true),
                    TelegramLastname = table.Column<string>(type: "text", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                schema: "bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftDelete = table.Column<bool>(type: "boolean", nullable: false),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    TelegramMessageId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messages_chats_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "bot",
                        principalTable: "chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_ChatId",
                schema: "bot",
                table: "messages",
                column: "ChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages",
                schema: "bot");

            migrationBuilder.DropTable(
                name: "users",
                schema: "bot");

            migrationBuilder.DropTable(
                name: "chats",
                schema: "bot");
        }
    }
}
