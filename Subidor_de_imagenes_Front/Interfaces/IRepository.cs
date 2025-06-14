using Subidor_de_imagenes_Front.Models;

namespace Subidor_de_imagenes_Front.Interfaces
{
    public interface IRepository
    {
    Task<Photos>UploadImage(Photos reinaCrear);

    Task<Result> DeleteImage(int id);

    Task<Result> GetPhotoListAsync();
    
    Task<Result> DownloadPhotoAsync(int id);


    }
}
