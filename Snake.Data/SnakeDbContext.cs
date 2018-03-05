using Microsoft.EntityFrameworkCore;
using System;

public class SnakeDbContext:DbContext
{
    public SnakeDbContext()
    {
    }

    public SnakeDbContext(DbContextOptions options)
        :base(options)
    {
    }

    public DbSet<ScoreBoard> ScoreBoards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ScoreBoardConfig());
    }
}

