using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ScoreBoardConfig : IEntityTypeConfiguration<ScoreBoard>
{
    public void Configure(EntityTypeBuilder<ScoreBoard> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.UserName)
            .HasMaxLength(30)
            .IsRequired();
    }
}