namespace WXWork3rd.Common.Models;

public class WXBase
{
    /// <summary>
    /// 出错返回码，为0表示成功，非0表示调用失败
    /// </summary>
    public int errcode { get; set; }
    public string? errmsg { get; set; }

}


