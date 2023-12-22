using Microsoft.AspNetCore.Http;

namespace WXWork3rd.Common.Extensions;

public static class RequestExtensions
{
    public static bool IsWXBrowse(this HttpRequest request)
    {
        return request.Headers["User-Agent"].ToString().ToLower().Contains("micromessenger");
    }
}
