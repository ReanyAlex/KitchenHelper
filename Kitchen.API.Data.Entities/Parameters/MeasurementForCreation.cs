using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class MeasurementForCreation
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string ShortHand { get; set; }
    }
}
