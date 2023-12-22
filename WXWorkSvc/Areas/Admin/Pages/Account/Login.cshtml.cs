using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WXWork3rd.Models.WXWork;

namespace WXWork3rd.Areas.Admin.Pages.Account;

public class LoginModel : PageModel
{
    public IActionResult OnGet([FromServices]WXWork wx, string returnUrl = "/")
    {
        return Redirect(wx.GetOAuthUrl(Request, returnUrl));
    }
}
