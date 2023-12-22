namespace WXWork3rd.Common.Models;
public class ResponseAccessToken : WXBase
{
    public string access_token { get; set; } = default!;
    public int expires_in { get; set; }
}