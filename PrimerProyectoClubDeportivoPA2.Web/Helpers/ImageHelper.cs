﻿namespace PrimerProyectoClubDeportivoPA2.Web.Helpers
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string nameFile, string folder)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{nameFile}{guid}.png";
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                $"wwwroot\\images\\{folder}",
                file);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return $"~/images/{folder}/{file}";
        }
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
