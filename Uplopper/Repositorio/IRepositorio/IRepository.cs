
using Uplopper.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Uplopper.Repositorio.IRepositorio
{
    public interface IRepository
    {


       

        bool UploadImage(Photos image);

        bool DeleteImagen(int idImage);

        List<Photos> GetImageList();


        List<Photos> DownloadImage(int idImage);


    }
}
