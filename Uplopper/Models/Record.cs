using System.ComponentModel.DataAnnotations;

namespace Uplopper.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime RecordTime { get; set; }

        [Required]
        public string? Action { get; set; }

        [Required]
        public string NameObject { get; set; }




    }
}
