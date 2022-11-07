using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace National.Repository.Entity
{
    public partial class NationalContext : DbContext
    {
        public NationalContext()
        {
        }

        public NationalContext(DbContextOptions<NationalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Workflow> Workflows { get; set; } = null!;
        public virtual DbSet<WorkflowApproval> WorkflowApprovals { get; set; } = null!;
        public virtual DbSet<WorkflowDetail> WorkflowDetails { get; set; } = null!;
        public virtual DbSet<WorkflowLevel> WorkflowLevels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("nextval('\"User_user_id_seq\"'::regclass)");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .HasColumnName("designation");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(100)
                    .HasColumnName("mobile_no");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .HasColumnName("photo");

                entity.Property(e => e.ProofOfId)
                    .HasMaxLength(100)
                    .HasColumnName("proof_of_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.UserProcess)
                    .HasMaxLength(100)
                    .HasColumnName("user_process");
            });

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.ToTable("workflow");

                entity.Property(e => e.WorkflowId).HasColumnName("workflow_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(10000)
                    .HasColumnName("description");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.WorkflowName)
                    .HasMaxLength(1000)
                    .HasColumnName("workflow_name ");
            });

            modelBuilder.Entity<WorkflowApproval>(entity =>
            {
                entity.ToTable("workflow_approval");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Details)
                    .HasMaxLength(1000)
                    .HasColumnName("details");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("short_description");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.WorkflowLevelDetails)
                    .HasMaxLength(1000)
                    .HasColumnName("workflow_level_details ");

                entity.Property(e => e.WorkflowName)
                    .HasMaxLength(1000)
                    .HasColumnName("workflow_name ");
            });

            modelBuilder.Entity<WorkflowDetail>(entity =>
            {
                entity.ToTable("workflow_detail");

                entity.Property(e => e.WorkflowDetailId).HasColumnName("workflow_detail_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.CurrentState).HasColumnName("current_state ");

                entity.Property(e => e.Predecessor).HasColumnName("predecessor");

                entity.Property(e => e.Successor).HasColumnName("successor");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.WorkflowId).HasColumnName("workflow_Id");
            });

            modelBuilder.Entity<WorkflowLevel>(entity =>
            {
                entity.ToTable("workflow_level");

                entity.Property(e => e.WorkflowLevelId).HasColumnName("workflow_level_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("character varying")
                    .HasColumnName("created_date");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("character varying")
                    .HasColumnName("updated_date");

                entity.Property(e => e.Users).HasColumnName("users");

                entity.Property(e => e.WorkflowLevelName)
                    .HasColumnType("character varying")
                    .HasColumnName("workflow_level_ name");

                entity.HasOne(d => d.UsersNavigation)
                    .WithMany(p => p.WorkflowLevels)
                    .HasForeignKey(d => d.Users)
                    .HasConstraintName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
