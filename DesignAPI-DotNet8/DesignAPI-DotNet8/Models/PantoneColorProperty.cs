using System.ComponentModel.DataAnnotations;

namespace DesignAPI_DotNet8.Models
{
    public class PantoneColorProperty
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        
        public bool IsOkForStyle { get; set; } = true;
        public bool IsOkForMaterial { get; set; } = true;
        public bool IsActive { get; set; } = true;

        public ColorGroup? GolorGroupName {get; set;}
        // public string ImageUrl { get; set; }
    }
}
