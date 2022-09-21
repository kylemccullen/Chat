using Chat.Models;
using ChatApp.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chat.Controllers;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly ChatAppContext _context;

    public MessagesController(ChatAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Message>>> Get()
    {
        var result = await _context.Message
            .ToListAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Message>>> Post([FromBody] Message message)
    {
        var previousMessage = await _context.Message
            .FirstOrDefaultAsync(m => m.Name == message.Name);

        message.Color = previousMessage?.Color ?? RandomColor();

        await _context.AddAsync(message);
        await _context.SaveChangesAsync();

        return Ok(message);
    }

    private static string RandomColor()
    {
        var random = new Random();
        return $"#{random.Next(0x1000000):X6}";
    }
}
