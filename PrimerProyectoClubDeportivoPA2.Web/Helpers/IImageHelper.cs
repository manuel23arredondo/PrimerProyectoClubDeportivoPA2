namespace PrimerProyectoClubDeportivoPA2.Web.Helpers
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Threading.Tasks;

    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string nameFile, string folder);

        public async Task<string> UpdateImageAsync(IFormFile imageFile, string url)
        {
            string urlTemp = url.Substring(1);
            urlTemp = $"wwwroot{urlTemp}";

            using (var stream = new FileStream(urlTemp, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return url;
        }
    }
}
