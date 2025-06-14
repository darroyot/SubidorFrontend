using AutoMapper;
using System.Runtime;
using Uplopper.Models;

namespace Uplopper.Automapper
{
    public class AutoMapperUp :Profile
    {

        public AutoMapperUp() {

            CreateMap<Photos, DTOPhotos>().ReverseMap();




        }





    }
}
