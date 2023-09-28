using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Common
{
    public class HandleFile
    {
        private readonly string rootPath;
        private readonly string folderSaveFile;
        public HandleFile(string folderSaveFile = "others", string rootPath = "wwwroot/uploads")
        {
            this.rootPath = rootPath;
            this.folderSaveFile = folderSaveFile;
        }

        private string HandleSaveFile(IFormFile file)
        {
            string pathSave = $"";

            if (file != null)
            {
                int index = file.FileName.IndexOf('.');
                string fileName = $"{Guid.NewGuid()}.{file.FileName.Substring(index + 1)}";
                string pathSys = Path.Combine(Directory.GetCurrentDirectory(), $"{this.rootPath}/{this.folderSaveFile}", fileName);
                pathSave = $"/{this.rootPath.Substring(8)}/{this.folderSaveFile}/{fileName}";
                var stream = new FileStream(pathSys, FileMode.Create);
                file.CopyToAsync(stream);
            }

            return pathSave;
        }

        public string Save(IFormFile file)
        {
            if (!Directory.Exists($@"{rootPath}/{folderSaveFile}"))
            {
                Directory.CreateDirectory($@"{rootPath}/{folderSaveFile}");
                return HandleSaveFile(file);
            }
            else
            {
                return HandleSaveFile(file);
            }
        }

        public bool Delete(string fileName)
        {
            string pathDelete = $"{this.rootPath}/{this.folderSaveFile}/{fileName}";
            if (fileName != string.Empty)
            {
                if (File.Exists(pathDelete))
                {
                    File.Delete(pathDelete);
                    return true;
                }
            }

            return false;
        }
    }
}
