using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models;

public class TestRequest
{
    [Required]
    public string Data { get; set; } = null!;
}
