using AnimalChat.Web.Models;

namespace AnimalChat.Web.Services
{
    public class ImageService(HttpClient httpClient)
    {
        public async Task<IEnumerable<Image>> GetImagesAsync(CancellationToken cancellationToken = default)
        {
            var result = await httpClient.GetFromJsonAsync<Image[]>("/images", cancellationToken);
            return result ?? [];
        }

        public async Task<Image> GetImageAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await httpClient.GetFromJsonAsync<Image>($"/images/{id}", cancellationToken);
            return result?? new Image();
        }
    }


}
