using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ScoreBoardConfig : IEntityTypeConfiguration<ScoreBoard>
{
    public void Configure(EntityTypeBuilder<ScoreBoard> builder)
    {
        builder.HasKey(e => e.Id);
    }
}