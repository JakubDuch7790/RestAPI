using GodlessAPI.Models.Dto;

namespace GodlessAPI.Data;

public static class GodlessStore
{
    public static List<GodlessDTO> GodlessList = new List<GodlessDTO> {

        new GodlessDTO { Id = 1, Name = "Thor", Pantheon = "Viking", Universe = "Marvel"},
        new GodlessDTO { Id = 2, Name = "Odin", Pantheon = "Viking", Universe = "Marvel"}
    };
}
