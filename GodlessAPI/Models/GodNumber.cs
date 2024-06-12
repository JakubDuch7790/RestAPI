using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodlessAPI.Models
{
    public class GodNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GodNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
