namespace Subidor_de_imagenes_Front.Models
{
    public class Result
    {

        public bool Ok { get; set; }
        public string? details { get; set; }

        public List<Photos>? PhotoList { get; set; }


    }
}
