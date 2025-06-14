namespace Subidor_de_imagenes_Front.Models
{
    public class Ruta
    {
        

        public static string UrlBaseApi = "https://localhost:7066/";
        public static string RutasSave = UrlBaseApi + "api/Upload/Upload_Image";
        public static string RutasGet = UrlBaseApi + "api/Upload/GetList";
        public static string RutasDel = UrlBaseApi + "api/Upload/PhotoDelete/";
        public static string RutasDown = UrlBaseApi + "api/Upload/DownloadPhoto/";

    }
}
