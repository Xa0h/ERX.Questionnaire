using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class ERXContext : DbContext
    {
        public ERXContext()
        {
        }

        public ERXContext(DbContextOptions<ERXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<HomeAddress> HomeAddresses { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        public virtual DbSet<QuestionnaireGroup> QuestionnaireGroups { get; set; }
        public virtual DbSet<WorkAddress> WorkAddresses { get; set; }
        public virtual DbSet<WorkInfo> WorkInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ERX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "User");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<HomeAddress>(entity =>
            {
                entity.ToTable("HomeAddress", "User");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SubDistrict).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HomeAddresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__HomeAddre__UserI__286302EC");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("Occupation", "User");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.OccupationType)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Personal__1788CC4CBCCDABBB");

                entity.ToTable("PersonalInfo", "User");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PersonalInfos)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__PersonalI__Count__25869641");
            });

            modelBuilder.Entity<Questionnaire>(entity =>
            {
                entity.ToTable("Questionnaire", "User");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questionn__Group__35BCFE0A");
            });

            modelBuilder.Entity<QuestionnaireGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__Question__149AF36AEB16F6B9");

                entity.ToTable("QuestionnaireGroup", "User");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<WorkAddress>(entity =>
            {
                entity.ToTable("WorkAddress", "User");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SubDistrict).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkAddresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WorkAddre__UserI__2B3F6F97");
            });

            modelBuilder.Entity<WorkInfo>(entity =>
            {
                entity.HasKey(e => e.BusinessId)
                    .HasName("PK__WorkInfo__F1EAA36E5CEB5FA0");

                entity.ToTable("WorkInfo", "User");

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.WorkInfos)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK__WorkInfo__Occupa__30F848ED");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkInfos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WorkInfo__UserId__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
