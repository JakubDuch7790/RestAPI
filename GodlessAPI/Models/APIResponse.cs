using System.Net;

namespace GodlessAPI.Models;

public class APIResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccessful { get; set; }
    public List<string> ErrorMessages { get; set; }
    public object Result { get; set; }
}
