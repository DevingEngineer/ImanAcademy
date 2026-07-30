using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ImanAcademy.Models;

public partial class ImanAcademyContext : IdentityDbContext<ApplicationUser>
{

    public ImanAcademyContext(DbContextOptions<ImanAcademyContext> options)
        : base(options)
    {
    }
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public virtual DbSet<Category> Categories { get; set; }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Module> Modules => Set<Module>();
    public DbSet<SubModule> SubModules => Set<SubModule>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    public DbSet<QuizOption> QuizOptions => Set<QuizOption>();
    public DbSet<StepAttachment> StepAttachments => Set<StepAttachment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasIndex(rt => rt.TokenHash).IsUnique();
            entity.HasOne(rt => rt.User)
                  .WithMany()
                  .HasForeignKey(rt => rt.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        // ---------- Course ----------
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(c => c.Slug).IsUnique();
            entity.Property(c => c.Price).HasPrecision(10, 2);
            entity.Property(c => c.Currency).HasMaxLength(3);

            // Primitive collection stored as a JSON column (EF Core 8+ feature)
            entity.Property(c => c.Tags);

            entity.HasMany(c => c.Modules)
                  .WithOne(m => m.Course)
                  .HasForeignKey(m => m.CourseId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- Course <-> Instructor (many-to-many via explicit join entity) ----------
        modelBuilder.Entity<CourseInstructor>(entity =>
        {
            entity.HasKey(ci => new { ci.CourseId, ci.InstructorId });

            entity.HasOne(ci => ci.Course)
                  .WithMany(c => c.CourseInstructors)
                  .HasForeignKey(ci => ci.CourseId);

            entity.HasOne(ci => ci.Instructor)
                  .WithMany(i => i.CourseInstructors)
                  .HasForeignKey(ci => ci.InstructorId);
        });

        // ---------- Module ----------
        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasMany(m => m.SubModules)
                  .WithOne(sm => sm.Module)
                  .HasForeignKey(sm => sm.ModuleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- SubModule ----------
        modelBuilder.Entity<SubModule>(entity =>
        {
            entity.HasMany(sm => sm.Steps)
                  .WithOne(s => s.SubModule)
                  .HasForeignKey(s => s.SubModuleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- Step (TPH: single table, discriminated by "StepType") ----------
        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasDiscriminator<string>("StepType")
                  .HasValue<ContentStep>("Content")
                  .HasValue<VideoStep>("Video")
                  .HasValue<QuizStep>("Quiz");
        });

        // ---------- ContentStep -> StepAttachment ----------
        modelBuilder.Entity<StepAttachment>(entity =>
        {
            entity.HasOne(a => a.ContentStep)
                  .WithMany(cs => cs.Attachments)
                  .HasForeignKey(a => a.ContentStepId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- QuizStep -> QuizQuestion -> QuizOption ----------
        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.HasOne(q => q.QuizStep)
                  .WithMany(qs => qs.Questions)
                  .HasForeignKey(q => q.QuizStepId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(q => q.Options)
                  .WithOne(o => o.QuizQuestion)
                  .HasForeignKey(o => o.QuizQuestionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
