using System.Runtime.CompilerServices;

using WXWork3rd.Common.Models;

namespace WXWork3rd.Common.Extensions;

public static class WXResponseExtensions
{
    public static void Valid(this WXBase? wxbase, [CallerMemberName] string memberName = "")
    {
        if (wxbase == null)
            throw new Exception($"{memberName}——返回空值");
        if (wxbase.errcode != 0)
            throw new Exception($"{memberName}\r\nErrorCode:{wxbase.errcode}\r\nMessage={wxbase.errmsg}");
    }
}
