namespace WXWork3rd.Data;
public class TSuiteCorp
{
    [StringLength(32)]
    [Column(Order = 0)]
    public string SuiteId { get; set; } = default!;
    [StringLength(32)]
    [Column(Order = 1)]
    public string CorpId { get; set; } = default!;

}