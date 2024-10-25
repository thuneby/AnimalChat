using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AnimalChat.ApiService.Models;

namespace AnimalChat.ApiService.Controllers
{
    public class ImageController : Controller
    {
        public async Task<List<Image>> GetImagesAsync()
        {
            const string imageFile = "/Setup/images/Images_list.json";
            var images = new List<Image>();

            if (!System.IO.File.Exists(imageFile)) return images;
            var json = await System.IO.File.ReadAllTextAsync(imageFile);

            try
            {
                images = JsonSerializer.Deserialize<List<Image>>(json) ?? new List<Image>();
            }
            catch (JsonException)
            {
                // Log the error.
            }
            return images;
        }
    }
}
