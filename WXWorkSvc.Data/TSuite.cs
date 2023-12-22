global using System.ComponentModel.DataAnnotations;

namespace WXWork3rd.Data;
/// <summary>
/// 每个内部应用创建一个SuiteId
/// 服务商SuiteId就是CorpId
/// 
/// </summary>
public class TSuite
{
    [StringLength(32)]
    [Display(Name = "应用Id")]
    public string Id { get; set; } = default!;
    [Display(Name = "名称")]
    public string Name { get; set; } = default!;
    [StringLength(128)]
    public string Secret { get; set; } = default!;
    public string Ticket { get; set; } = "";
    [Display(Name = "Ticket推送时间")]
    public DateTime DTTicket { get; set; }
    public string Token { get; set; } = "";
    [Display(Name = "Token到期时间")]
    public DateTime DTTokenExpires { get; set; }
}
