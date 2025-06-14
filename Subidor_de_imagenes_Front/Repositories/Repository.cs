using Newtonsoft.Json;
using Subidor_de_imagenes_Front.Interfaces;
using Subidor_de_imagenes_Front.Models;
using System;
using System.Text;

namespace Subidor_de_imagenes_Front.Repositories
{
    public class Repository : IRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _url = "http://localhost:56314/";//hay que encriptarla

        public Repository(IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;


        }

        public async Task<Result> GetPhotoListAsync()
        {
            var peticion = new HttpRequestMessage(HttpMethod.Get, Ruta.RutasGet);

            Result result = new Result();

            try
            {
                var client = _clientFactory.CreateClient();
                HttpResponseMessage request = await client.SendAsync(peticion);
                if (request.IsSuccessStatusCode)
                {

                    string jsonString = await request.Content.ReadAsStringAsync();


                    result = JsonConvert.DeserializeObject<Result>(jsonString);
                }
                else
                {
                    result.Ok = false;
                    result.details = "Ocurrió algun problema con la respuesta";

                }
            }
            catch (Exception ex)
            {
                result.Ok = false;
                result.details = ex.Message;
            }

            return result;
        }


        public async Task<Result> DeleteImage(int id)
        {
            var peticion = new HttpRequestMessage(HttpMethod.Delete,Ruta.RutasDel + id);

            var result = new Result();

                try
                {
                    var cliente = _clientFactory.CreateClient();
                    HttpResponseMessage respuesta = await cliente.SendAsync(peticion);
                    if (respuesta.IsSuccessStatusCode)
                    {

                        string jsonString = await respuesta.Content.ReadAsStringAsync();


                        result = JsonConvert.DeserializeObject<Result>(jsonString);
                    }
                    else
                    {


                    }
                }
                catch (Exception ex)
                {

                }

            return result;


        }
    
    public async Task<Photos> UploadImage(Photos Image)
        {
            var peticion = new HttpRequestMessage(HttpMethod.Post, Ruta.RutasSave);

            var result = new Photos();

            ///Se instancia Multipartformdatacontent ,que permite enviar datos en formato multipart/formdata es parta archivos con datos normalmente
            if (Image != null)
            {
                peticion.Content = new StringContent(JsonConvert.SerializeObject(Image), Encoding.UTF8, "application/json");
                try
                {
                    var cliente = _clientFactory.CreateClient();
                    HttpResponseMessage respuesta = await cliente.SendAsync(peticion);
                    if (respuesta.IsSuccessStatusCode)
                    {

                        string jsonString = await respuesta.Content.ReadAsStringAsync();


                        result = JsonConvert.DeserializeObject<Photos>(jsonString);
                    }
                    else
                    {
               

                    }
                }
                catch (Exception ex)
                {
            
                }





            }
            else
            {

     
            }


            return result;


        }

        public async Task<Result> DownloadPhotoAsync(int id)
        {


            var peticion = new HttpRequestMessage(HttpMethod.Get, Ruta.RutasDown + id);

            var result = new Result();

            try
            {
                var cliente = _clientFactory.CreateClient();
                HttpResponseMessage respuesta = await cliente.SendAsync(peticion);
                if (respuesta.IsSuccessStatusCode)
                {

                    string jsonString = await respuesta.Content.ReadAsStringAsync();


                    result = JsonConvert.DeserializeObject<Result>(jsonString);
                }
                else
                {


                }
            }
            catch (Exception ex)
            {

            }

            return result;







        }
    }
}
