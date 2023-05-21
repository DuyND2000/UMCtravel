using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Common.Constants;
using System;
using System.IO;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager + ", " + Constant.Role.Employee)]
    public class BaseController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BaseController()
        {

        }
        public BaseController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string GetUrl(IFormFile fileUpload,string imageFolderBranch = null)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath
                , $"assets/images{(string.IsNullOrWhiteSpace(imageFolderBranch)?"":"/"+imageFolderBranch)}");
            // Cái dòng trên để thêm cái /imageFolderBranch nếu imageFolderBranch khác null hoặc trắng xóa thôi
            // Nếu imageFolderBranch == null thì nó vào assets/images/ảnh.png
            Directory.CreateDirectory(uploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString().Substring(0, 8) + "_" + fileUpload.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileUpload.CopyTo(fileStream);
            }
            return $"assets/images{(string.IsNullOrWhiteSpace(imageFolderBranch) ? "" : "/" + imageFolderBranch)}/{uniqueFileName}";
        }
    }
}
