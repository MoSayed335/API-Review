using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public bool status { get; set; }
    }
}
