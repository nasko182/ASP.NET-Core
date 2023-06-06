﻿namespace Forum.Data;

using Microsoft.EntityFrameworkCore;
using Forum.Data.Models.Models;

using Configuration;

public class ForumDbContext : DbContext
{
    public ForumDbContext(DbContextOptions<ForumDbContext> options)
        : base(options)
    {

    }

    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

