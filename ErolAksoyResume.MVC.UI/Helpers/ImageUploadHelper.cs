using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.Helpers
{
    public static class ImageUploadHelper
    {


        /// <summary>
        /// Image Upload Async
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <param name="imgFile"></param>
        /// <param name="imagePath"></param>
        /// <returns>Return (string) image name</returns>
        public static async Task<string> ImageUploadAsync(IWebHostEnvironment webHostEnvironment, IFormFile imgFile, string imagePath = "img/")
        {
            if (imgFile != null && (imgFile.ContentType == "image/jpeg" || imgFile.ContentType == "image/png" || imgFile.ContentType == "image/jpg"))
            {
                var filePath = Path.Combine(webHostEnvironment.WebRootPath + $@"{imagePath}");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var imgExtension = Path.GetExtension(imgFile.FileName);
                string imgName = Guid.NewGuid() + imgExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{imagePath}", imgName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imgFile.CopyToAsync(fileStream);
                }
                return imgName;
            }

            return null;
        }


    }
}
