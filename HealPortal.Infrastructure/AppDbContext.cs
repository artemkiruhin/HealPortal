using HealPortal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealPortal.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uuid");
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.Username).IsRequired();
            builder.Property(e => e.PasswordHash).IsRequired();
            builder.Property(e => e.Role).IsRequired();
            builder.Property(e => e.RegisteredAt).IsRequired();

            builder
                .HasMany(e => e.Comments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        });
        modelBuilder.Entity<CommentEntity>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uuid");
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.PostId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.UserId);
            builder
                .HasOne(e => e.Post)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.PostId);
        });
        modelBuilder.Entity<PostEntity>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uuid");
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.Likes).IsRequired();
            builder.Property(e => e.Dislikes).IsRequired();
            builder.Property(e => e.Watchers).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();

            builder
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId);
            builder
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts);
        });
        modelBuilder.Entity<TagEntity>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uuid");
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.TagName).IsRequired();

            builder
                .HasMany(e => e.Posts)
                .WithMany(e => e.Tags);
        });
    }
}