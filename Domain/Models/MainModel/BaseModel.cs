using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.MainModel
{
    public class BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }


        public bool? Local_Flag { get; set; }
        public bool? SAP_Flag { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public DateTime UpdatedAt { get; set; }
        // public bool IsDeleted { get; set; }
    }
}
