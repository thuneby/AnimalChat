using System.Text.Json;
using AnimalChat.ApiService.Models;

namespace AnimalChat.ApiService.Apis

{
    public static class ImageApi
    {
        public static async Task<List<Image>> GetImagesAsync()
        {
            const string imageFile = @".\Setup\ImageList.json";
            const string imagesFolder = @".\Images";
            var images = new List<Image>();

            if (!File.Exists(imageFile)) return images;
            var json = await File.ReadAllTextAsync(imageFile);

            try
            {
                images = JsonSerializer.Deserialize<List<Image>>(json) ?? new List<Image>();
                foreach (var image in images)
                {
                    var imagePath = Path.Combine(imagesFolder, image.FileName);
                    if (File.Exists(imagePath))
                    {
                        image.Data = await File.ReadAllBytesAsync(imagePath);
                    }
                }
            }
            catch (JsonException)
            {
                // Log the error.
            }
            return images;
        }

        public static async Task<Image> GetImageAsync(int id)
        {
            var images = await GetImagesAsync();
            return images.FirstOrDefault(i => i.Id == id)?? new Image();
        }
    }
}
