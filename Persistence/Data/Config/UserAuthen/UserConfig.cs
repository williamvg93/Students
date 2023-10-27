using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.UserAuthen;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnName("userName")
            .HasColumnType("varchar")
            .HasMaxLength(50);


            builder.Property(p => p.Password)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder
           .HasMany(p => p.Rols)
           .WithMany(r => r.Users)
           .UsingEntity<UserRol>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.UserRols)
               .HasForeignKey(ut => ut.RolIdFk),

               j => j
               .HasOne(et => et.User)
               .WithMany(et => et.UserRols)
               .HasForeignKey(el => el.UserIdFk),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.UserIdFk, t.RolIdFk });

               });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserIdFk);
        }

    }
}