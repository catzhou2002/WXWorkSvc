global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using System.ComponentModel.DataAnnotations.Schema;

namespace WXWork3rd.Data;

[EntityTypeConfiguration(typeof(TCorpTokenConfig))]
public class TCorpToken : TSuiteCorp
{
    public int AgentId { get; set; }
    public string Token { get; set; } = default!;
    public DateTime DTExpiresToken { get; set; }
    public string JsTicket { get; set; } = "";
    public string AgentJsTicket { get; set; } = "";
    public DateTime DTExpiresTicket { get; set; }
    [ForeignKey(nameof(SuiteId))]
    public virtual TSuite Suite { get; set; } = default!;
}

public class TCorpTokenConfig : IEntityTypeConfiguration<TCorpToken>
{
    public void Configure(EntityTypeBuilder<TCorpToken> builder)
    {
        builder.HasKey(ii => new { ii.SuiteId, ii.CorpId,ii.AgentId });
    }
}

