using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BildWebApp.Models;
[Table("Categories", Schema ="Shop")]
public class Category
{
    [Key]
    public int ID { get; set; }
    [Required, MaxLength(250)]
    public string? Name { get; set; }
    public int DisplayOrder { get; set; }
}

