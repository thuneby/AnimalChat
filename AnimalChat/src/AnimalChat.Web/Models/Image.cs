using System.ComponentModel.DataAnnotations;

namespace AnimalChat.Web.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; } = string.Empty;
        public string AnimalName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string MimeType { get; set; } = "image/jpeg";
        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}
