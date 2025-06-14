using System.ComponentModel.DataAnnotations;

namespace Uplopper.Models
{
    public class Photos
    {
     [Key]
     public int Id { get; set; }

     [Required]

     public string? Name { get; set; }
     
    [Required]
     public string ? Image { get; set; }
     
    [Required]
    public DateTime? CreatedDate { get; set; }
     




    }
}
