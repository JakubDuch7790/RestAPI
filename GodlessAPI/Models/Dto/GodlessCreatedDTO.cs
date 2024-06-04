using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodlessAPI.Models.Dto
{
    public class GodlessCreatedDTO
    {
        public string Name { get; set; }
        public DateTime Creation { get; set; }

        //public string Pantheon { get; set; }
        //public string Universe { get; set; }

    }
}
