using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MentorRazorPage.Utilities
{
    public static class Extension
    {
        public static bool  GetType(this IFormFile photo)
        {
            if (!photo.ContentType.Contains("image/"))
            {
                return false;
            }
            return true;
        }
        public static bool GetSize(this IFormFile photo,int size)
        {
            if (photo.Length / 1024 > size)
            {
                return false;
            }
            return true;
        }
        public async static Task<string> SaveFileAsync(string root,string folder, IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string rootPath = Path.Combine(root, folder, fileName);
            using (FileStream fileStream = new FileStream(rootPath, FileMode.Create))
            {
                 await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
