using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodlessAPI.Models.Dto
{
    public class GodlessDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pantheon { get; set; }
        public string Universe { get; set; }

    }
}
