using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Subidor_de_imagenes_Front.Interfaces;
using Subidor_de_imagenes_Front.Models;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Subidor_de_imagenes_Front.Controllers
{
    public class SubidorController : Controller
    {

        private IRepository _repo;

        public SubidorController(IRepository repo)
        {
            _repo = repo;
        }



        public async Task<IActionResult> Main()
        {

     

            Result ResultPhotos=await _repo.GetPhotoListAsync();

            return View(ResultPhotos);
        }

        public async Task<IActionResult> Downloader(int id)
        {
            Result result = await _repo.DownloadPhotoAsync(id);
            if (result.Ok)
            {

                if (result.PhotoList[0].Image == null) {
                    return RedirectToAction("Main", "Subidor");
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(),"/",result.PhotoList[0].Name);
                
                byte[] bytesImagen;

                try
                {
                    bytesImagen = Convert.FromBase64String(result.PhotoList[0].Image);
                }
                catch
                {
                    return BadRequest("Base64 inválido.");
                }

                var nombreArchivo = string.IsNullOrEmpty(result.PhotoList[0].Name) ? "imagen.png" : result.PhotoList[0].Name;

                return File(bytesImagen, "image/png", path);




            }
            return RedirectToAction("Main", "Subidor");
        }



        public async Task<IActionResult> Deleter(int id)
        {

            Result result =await _repo.DeleteImage(id);


            return RedirectToAction("Main", "Subidor");

        }


        [HttpPost]
        public async Task<IActionResult> SubidaImagensync(IFormFile Photo)
        {

            string extensionArchivo = Path.GetExtension(Photo.FileName);
                              
            if (Photo.Length < 16777216 && extensionArchivo==".png")
            {                  


                MemoryStream memoryStream = new MemoryStream();

                await Photo.CopyToAsync(memoryStream);
                Byte[] imageBytes = memoryStream.ToArray();
                string image64 = Convert.ToBase64String(imageBytes);

                Photos image = new Photos
                {
                    Image = image64,
                    CreatedDate = DateTime.Now,
                    Name = Photo.FileName
                };

                var result = await _repo.UploadImage(image);


                return RedirectToAction("Main", "Subidor");
            }
            else
            {


                return BadRequest();
            }
        }


    }
}
