using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodlessAPI.Models.Dto
{
    public class GodNumberCreatedDTO
    {
        [Required]
        public int GodNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
