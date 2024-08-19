// <copyright file="UserSession.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models;

public class UserSession : BaseModel, IEntity, IEntityRegister
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for UserId.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for RefreshToken.
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for RefreshToken.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for DateRevoked.
    /// </summary>
    public DateTime? DateRevoked { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for DateExpired.
    /// </summary>
    public DateTime DateExpired { get; set; }

    /// <summary>
    ///     Model builder to create it own model to declare field and relation.
    /// </summary>
    /// <param name="modelbuilder"></param>
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<UserSession>(entity =>
                                         {
                                             entity.HasKey(e => e.Id);

                                             entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                                             entity.Property(e => e.UserId).HasColumnName("user_id");

                                             entity.Property(e => e.DateExpired).HasColumnName("date_expired");

                                             entity.Property(e => e.DateRevoked).HasColumnName("date_revoked");

                                             entity.Property(e => e.RefreshToken)
                                                   .IsRequired()
                                                   .HasMaxLength(1000)
                                                   .HasColumnName("refresh_token")
                                                   .IsUnicode(false);

                                             entity.Property(e => e.Token)
                                                   .IsRequired()
                                                   .HasMaxLength(1000)
                                                   .HasColumnName("token")
                                                   .IsUnicode(false);

                                             entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                                             entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                                             entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                                             entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                                             entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                                             entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

                                             entity.HasQueryFilter(x => x.DeletedDate == null);

                                             entity.ToTable("user_sessions");
                                         });
    }
}