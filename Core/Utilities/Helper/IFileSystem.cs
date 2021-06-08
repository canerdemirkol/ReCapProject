using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;

namespace Core.Utilities.Helper
{
    public interface IFileSystem
    {
        string Add(IFormFile file, string path);
        string Update(IFormFile file, string path, string sourcePath);
        void Delete(string path);
        String FileToBase64(IFormFile file);
        string CreateNewPath(IFormFile file, string folderName);
        String ImagePathToBase64String(string path);
        String ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format);
        Image Base64ToImage(string base64String);

        string GetUrlImageBase64(string resimYol);
    }
}
