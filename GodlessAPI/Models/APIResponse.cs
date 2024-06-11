using System.Net;

namespace GodlessAPI.Models;

public class APIResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccessful { get; set; } = true;
    public List<string> ErrorMessages { get; set; }
    public object Result { get; set; }
}
