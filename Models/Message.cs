using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Models;

public class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column(Order = 0)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? Color { get; set; }
}
