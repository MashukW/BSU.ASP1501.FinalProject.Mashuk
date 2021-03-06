﻿using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.ConfigurationEntities
{
    public class UserProfileConfig : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfig()
        {
            HasKey(p => p.Id)
                .HasRequired(p => p.User)
                .WithRequiredPrincipal(p => p.UserProfile);
            
            Property(p => p.MiddleName)
                .HasMaxLength(25);

            Property(p => p.LastName)
                .HasMaxLength(25);

            Property(p => p.DateOfBirth)
                .HasColumnType("date");

            Property(p => p.Gender)
                .HasMaxLength(8);

            Property(p => p.MobilePhoneNumber)
                .HasMaxLength(20);

            Property(p => p.Country)
                .HasMaxLength(20);

            Property(p => p.City)
                .HasMaxLength(20);

            Property(p => p.Street)
                .HasMaxLength(30);

            Property(p => p.CompanyOfWork)
                .HasMaxLength(30);

            Ignore(p => p.Age);
        }
    }
}
