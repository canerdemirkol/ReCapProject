using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper : IFileSystem
    {
        private static string imagesCurrentDirectoryPath = Environment.CurrentDirectory + @"\wwwroot";
        public string Add(IFormFile file, string folderName)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var path1 = newPath(file);
            var result = $@"{imagesCurrentDirectoryPath}\images\{folderName}\{path1}";
            File.Move(sourcepath, result);
            return $@"/images/{folderName}/{path1}";
        }

        public void Delete(string path)
        {
            var newPath = imagesCurrentDirectoryPath + path.Replace($@"/", $@"\");
            if (File.Exists(newPath))
                File.Delete(newPath);
        }
        public String ImagePathToBase64String(string path)
        {
            var newPath = imagesCurrentDirectoryPath + path.Replace($@"/", $@"\");
            using (Image image = Image.FromFile(newPath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public String FileToBase64(IFormFile file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public String ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        public string GetUrlImageBase64(string resimYol)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(resimYol);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public string Update(IFormFile file, string path, string sourcePath)
        {
            var result = Add(file, path);
            if (sourcePath.Length > 0)
            {
                Delete(sourcePath);
            }

            return result;
        }
        public string CreateNewPath(IFormFile file, string folderName)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath =
                $@"{Environment.CurrentDirectory}\wwwroot\images\{folderName}\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }

        private static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;//extension uzantı demek dosyanın uzantısını aldım png, jpeg gibi 

            //string path = Environment.CurrentDirectory + @"\wwwroot\images"; //Environment.CurrentDirectory geçerli çalışma dizininin tam yolunu alır veya ayarlar
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            //string result = $@"{path}\{newPath}";
            return newPath;
        }


    }
}
