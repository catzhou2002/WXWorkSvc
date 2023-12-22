namespace WXWork3rd.Data;
[EntityTypeConfiguration(typeof(TCorpUserConfig))]
public class TCorpUser : TSuiteCorp
{
    [StringLength(64)]
    public string UserId { get; set; } = default!;
    public bool IsAdmin { get; set; }
    [ForeignKey(nameof(SuiteId))]
    public virtual TSuite Suite { get; set; } = default!;
}
public class TCorpUserConfig : IEntityTypeConfiguration<TCorpUser>
{
    public void Configure(EntityTypeBuilder<TCorpUser> builder)
    {
        builder.HasKey(ii => new { ii.SuiteId, ii.CorpId, ii.UserId });
    }
}
