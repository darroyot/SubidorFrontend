



using System;
using Uplopper.Data;
using Uplopper.Models;
using Uplopper.Repositorio.IRepositorio;
using static System.Net.Mime.MediaTypeNames;

namespace Uplopper.Repository
{
    public class Repository:IRepository
    {
        private readonly AppDbContext _bd;

        public Repository(AppDbContext bd)
        {
            _bd = bd;
        }



        public bool UploadImage(Photos image)
        {

            _bd.Photos.Add(image).GetDatabaseValues();

            if (Save())
            {

                Record("U", image.Name);
                return true;
            }
            else
            {
                Record("FU",image.Name);
                return false;
            }

        
        }



        public bool DeleteImagen(int idImage)
        {
           Photos DelImage= _bd.Photos.Where(r => r.Id == idImage).FirstOrDefault();
            string name= DelImage?.Name;
            
            if (DelImage != null) {
              _bd.Photos.Remove(DelImage);

                if (Save())
                {

                    Record("D", name);
                    return true;
                }
                else
                {
                    Record("FD", name);
                    return false;
                }

         

               

                    }



            return Save();
        }

        void Record(string action,string nameObject)
        {
            Record record = new Record
            {
                Action = action,
                NameObject = nameObject,
                RecordTime= DateTime.Now
            };
            _bd.Record.Add(record);
            Save();

        }




        public List<Photos> GetImageList()
        {
            List<Photos> ImagesList = _bd.Photos.OrderBy(c => c.Name).ToList();



            return ImagesList;
        }

        public List<Photos> DownloadImage(int idImage)
        {
            List<Photos> ImagesList = new List<Photos>();
            Photos DownImage = _bd.Photos.Where(r => r.Id == idImage).FirstOrDefault();
            if (DownImage != null)
            {
                ImagesList.Add(DownImage);

                    Record("B", DownImage.Name);
           
            }
            return ImagesList;
        }

        public bool Save()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

     
    }
}
