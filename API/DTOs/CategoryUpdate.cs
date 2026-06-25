using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CategoryUpdate
    {
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public bool status { get; set; }
    }
}
