using System.ComponentModel.DataAnnotations;

namespace AnimalChat.ApiService.Models;

public class Image
{
    public int Id { get; set; }
    [Required]
    public string FileName { get; set; }
    public string Description { get; set; }
    public int Size { get; set; }
    public string MimeType { get; set; }
}