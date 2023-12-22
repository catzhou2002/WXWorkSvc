using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Web;

using WXWork3rd.Models.WXWork;

namespace WXWork3rd.Areas.Admin.Pages.Account;

public class CallbackModel : PageModel
{
    public string? Msg { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ReturnUrl { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync([FromServices]WXWork wx, string code,string state)
    {
        if(string.IsNullOrWhiteSpace(code))
        {
            Msg = "µÇÂ½Ê§°Ü£¡";
            return Page();
        }
        if (!string.IsNullOrEmpty(state))
            return Redirect($"{HttpUtility.UrlDecode(state)}/admin/account/callback/{ReturnUrl}?code={code}");


        var oauthUser = await wx.GetOAuthUserAsync(code);



        Msg=oauthUser.ToJsonString();
        return Page();
    }
}
