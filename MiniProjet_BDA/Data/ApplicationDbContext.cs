using MiniProjet_BDA.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_BDA.Data
{

    public class ApplicationDbContext : DbContext
    {
        internal object Jury;
        internal object Evaluations;
        internal object Jurys;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Defense> Defenses { get; set; }
        public DbSet<Jury> Juries { get; set; }
        public DbSet<StudentEvaluation> StudentEvaluations { get; set; }
        public DbSet<DefenseEvaluation> DefenseEvaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configuration de User
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired();

            // Héritage
            modelBuilder.Entity<Student>().HasBaseType<User>();
            modelBuilder.Entity<Professor>().HasBaseType<User>();
            modelBuilder.Entity<Jury>().HasBaseType<Professor>();

            // Team - Student1 & Student2
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Student1)
                .WithMany()
                .HasForeignKey(t => t.Student1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Student2)
                .WithMany()
                .HasForeignKey(t => t.Student2Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Project - Supervisor & Team
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Supervisor)
                .WithMany()
                .HasForeignKey(p => p.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Team)
                .WithMany()
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            // Defense - Project & Room
            modelBuilder.Entity<Defense>()
                .HasOne(d => d.Project)
                .WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Defense>()
                .HasOne(d => d.Room)
                .WithMany()
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Jury - Defense
            modelBuilder.Entity<Jury>()
                .HasOne(j => j.Defense)
                .WithMany()
                .HasForeignKey(j => j.DefenseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jury>()
                .HasIndex(j => new { j.Id, j.DefenseId })
                .IsUnique();

            // Student Evaluation
            modelBuilder.Entity<StudentEvaluation>()
                .HasKey(e => e.StudentEvaluationId);

            modelBuilder.Entity<StudentEvaluation>()
                .HasOne(e => e.Jury)
                .WithMany()
                .HasForeignKey(e => e.JuryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentEvaluation>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentEvaluation>()
                .HasIndex(e => new { e.JuryId, e.StudentId })
                .IsUnique();

            // Defense Evaluation
            modelBuilder.Entity<DefenseEvaluation>()
                .HasKey(e => e.DefenseEvaluationId);

            modelBuilder.Entity<DefenseEvaluation>()
                .HasOne(e => e.Jury)
                .WithMany()
                .HasForeignKey(e => e.JuryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DefenseEvaluation>()
                .HasOne(e => e.Defense)
                .WithMany()
                .HasForeignKey(e => e.DefenseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DefenseEvaluation>()
                .HasIndex(e => new { e.JuryId, e.DefenseId })
                .IsUnique();

        }
    }
}
