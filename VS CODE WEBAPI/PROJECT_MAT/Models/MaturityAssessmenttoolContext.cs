using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class MaturityAssessmenttoolContext : DbContext
    {
        public MaturityAssessmenttoolContext()
        {
        }

        public MaturityAssessmenttoolContext(DbContextOptions<MaturityAssessmenttoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectFunction> ProjectFunction { get; set; }
        public virtual DbSet<ProjectMembers> ProjectMembers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<UserSurvey> UserSurvey { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2U9Q181;Initial Catalog=MaturityAssessmenttool;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.AnswerId)
                    .HasName("PK__Answers__36937310A3C28855");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.Answer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AnswerWeightage).HasColumnName("Answer_Weightage");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Answers__Questio__36B12243");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("Project_id");

                entity.Property(e => e.FunctionId).HasColumnName("Function_id");

                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Projectname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK__Project__Functio__286302EC");
            });

            modelBuilder.Entity<ProjectFunction>(entity =>
            {
                entity.HasKey(e => e.FunctionId)
                    .HasName("PK__ProjectF__5F1A56BDC6B29D06");

                entity.Property(e => e.FunctionId).HasColumnName("Function_id");

                entity.Property(e => e.FunctionName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectMembers>(entity =>
            {
                entity.HasKey(e => e.ProjectMemberId)
                    .HasName("PK__ProjectM__DC57FC71F22BC09F");

                entity.Property(e => e.ProjectMemberId).HasColumnName("ProjectMember_id");

                entity.Property(e => e.ProjectId).HasColumnName("Project_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__ProjectMe__Proje__2B3F6F97");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ProjectMe__user___2C3393D0");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Question__B0B3E0BE26C7B445");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.FunctionId).HasColumnName("Function_id");

                entity.Property(e => e.Question)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK__Questions__Funct__33D4B598");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.SurveyId).HasColumnName("Survey_id");

                entity.Property(e => e.ProjectId).HasColumnName("Project_id");

                entity.Property(e => e.SurveyEndDate)
                    .HasColumnName("Survey_End_date")
                    .HasColumnType("date");

                entity.Property(e => e.SurveyStartDate)
                    .HasColumnName("Survey_Start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Surveyname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Survey)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Survey__Project___47DBAE45");
            });

            modelBuilder.Entity<UserSurvey>(entity =>
            {
                entity.Property(e => e.UserSurveyId).HasColumnName("User_Survey_id");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.SurveyId).HasColumnName("Survey_id");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserSurvey)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__UserSurve__Answe__3A81B327");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserSurvey)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__UserSurve__Quest__398D8EEE");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.UserSurvey)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK__UserSurve__Surve__3B75D760");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__B9BE370FF25F2A99");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasColumnName("userType")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
