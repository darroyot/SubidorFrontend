using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Uplopper.Models;
using Uplopper.Repositorio.IRepositorio;

namespace Uplopper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
       private readonly IMapper _mapper; 
       private readonly IRepository _repos;
        public UploadController(IMapper mapper,IRepository repo) {
        _mapper = mapper;
        _repos= repo;
        }



        [HttpPost("Upload_Image")]
        public IActionResult UploadImage([FromBody] DTOPhotos image)
        {
            Result result = new Result();
            try {

                Photos imagen = _mapper.Map<Photos>(image);
                result.Ok = _repos.UploadImage(imagen);
            } catch(Exception ex) { }

            return RedirectToAction("Main", "Subidor");
        }


        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            Result result = new Result();
            try
            {

                result.PhotoList = _repos.GetImageList();
                if (result.PhotoList != null)
                {
                    result.Ok = true;
                    result.details = "Success";

                }
                else
                {
                    result.Ok = false;
                    result.details = "Failed";

                }

            }
            catch (Exception ex)
            {

                result.Ok = false;
                result.details = "Failed";
            }


            return Ok(result);
        }


        [HttpDelete("PhotoDelete/{id:int}")]
        public IActionResult Delete(int id)
        {
            Result result = new Result();
            try
            {

                result.Ok = _repos.DeleteImagen(id);
                    if (result.Ok)
                {
                    result.details = "Eliminado correctamente";

                }
                else
                {
                    result.details = "Fallo";

                }
 

            }
            catch (Exception ex)
            {

                result.Ok = false;
                result.details = "Failed";
            }


            return Ok(result);
        }


        [HttpGet("DownloadPhoto/{id:int}")]
        public IActionResult DownloadPhoto(int id)
        {
            Result result = new Result();
            try
            {

                result.PhotoList = _repos.DownloadImage(id);
                if (result.PhotoList != null)
                {
                    result.Ok = true;
                    result.details = "Success";

                }
                else
                {
                    result.Ok = false;
                    result.details = "Failed";

                }

            }
            catch (Exception ex)
            {

                result.Ok = false;
                result.details = "Failed";
            }


            return Ok(result);
        }


    }
}
