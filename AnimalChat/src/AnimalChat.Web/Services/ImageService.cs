namespace AnimalChat.Web.Services
{
    public class ImageService(HttpClient httpClient)
    {
        public async Task<IEnumerable<Image>> GetImagesAsync(CancellationToken cancellationToken = default)
        {
            var result = await httpClient.GetFromJsonAsync<Image[]>("/images", cancellationToken);
            return result ?? [];
        }
    }

    public record Image(int Id, string FileName, string Description, int Size, string MimeType);
}
