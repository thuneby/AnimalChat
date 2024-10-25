using System.Text.Json;
using AnimalChat.ApiService.Models;

namespace AnimalChat.ApiService.Apis

{
    public static class ImageApi
    {
        public static async Task<List<Image>> GetImagesAsync()
        {
            const string imageFile = @".\Setup\ImageList.json";

            var images = new List<Image>();

            if (!File.Exists(imageFile)) return images;
            var json = await File.ReadAllTextAsync(imageFile);

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
