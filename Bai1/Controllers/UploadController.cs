using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bai1.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload(IFormFile fileUpload)
        {
            if (fileUpload != null)
            {
                string path = Path.Combine(hostingEnvironment.WebRootPath, @"uploads");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                fileUpload.CopyTo(new FileStream(Path.Combine(path, fileName), FileMode.Create));
                return View("KetQua");
            }


            return View("Index");
        }
    }
}
