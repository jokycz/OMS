using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class SystemUser
{
    public int SystemUserId { get; set; }

    [Required]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string UserPassword { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string UserFirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string UserLastName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string UserEmail { get; set; } = null!;

    public int UserStatus { get; set; }

    public int UserCreate { get; set; }

    public DateTime UserCreateDate { get; set; }

    public int? UserModify { get; set; }

    public DateTime? UserModifyDate { get; set; }

    public int? UserDelete { get; set; }

    public DateTime? UserDeleteDate { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.SystemUserId).HasName("PK_system_user");
            entity.ToTable("system_user");
            entity.Property(e => e.SystemUserId).HasColumnName("system_user_id");
            entity.Property(e => e.UserName).HasColumnName("user_name").HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasColumnName("user_password").HasMaxLength(50);
            entity.Property(e => e.UserFirstName).HasColumnName("user_first_name").HasMaxLength(50);
            entity.Property(e => e.UserLastName).HasColumnName("user_last_name").HasMaxLength(50);
            entity.Property(e => e.UserEmail).HasColumnName("user_email").HasMaxLength(50);
            entity.Property(e => e.UserStatus).HasColumnName("user_status");
            entity.Property(e => e.UserCreate).HasColumnName("user_create");
            entity.Property(e => e.UserCreateDate).HasColumnName("user_create_date");
            entity.Property(e => e.UserModify).HasColumnName("user_modify");
            entity.Property(e => e.UserModifyDate).HasColumnName("user_modify_date");
            entity.Property(e => e.UserDelete).HasColumnName("user_delete");
            entity.Property(e => e.UserDeleteDate).HasColumnName("user_delete_date");
        });
    }
}