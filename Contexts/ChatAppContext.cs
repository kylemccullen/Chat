using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Contexts;

public class ChatAppContext : DbContext
{
    public DbSet<Message> Message { get; set; }

    public ChatAppContext()
    {
    }

    public ChatAppContext(DbContextOptions options) : base(options)
    {
    }
}
