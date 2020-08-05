using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class Measurement
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string ShortHand { get; set; }
    }
}
