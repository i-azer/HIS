using System;
using HIS.Core.Entities;
using HIS.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HIS.Infrastructure.DataBase
{
    public class PatientModelBuilder
    {
        public PatientModelBuilder(EntityTypeBuilder<Patient> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).ValueGeneratedOnAdd();

            entityBuilder.OwnsOne(p => p.PatientName).Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientName.FirstName));
            entityBuilder.OwnsOne(p => p.PatientName).Property(p => p.MidName)
                .HasColumnName(nameof(Patient.PatientName.MidName));
            entityBuilder.OwnsOne(p => p.PatientName).Property(p => p.LastName)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientName.LastName));
            entityBuilder.OwnsOne(p => p.PatientName).Property(p => p.Suffix)
                .HasColumnName(nameof(Patient.PatientName.Suffix));
            entityBuilder.OwnsOne(p => p.PatientAddress).Property(p => p.AddressLine1)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientAddress.AddressLine1));
            entityBuilder.OwnsOne(p => p.PatientAddress).Property(p => p.AddressLine2)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientAddress.AddressLine2));
            entityBuilder.OwnsOne(p => p.PatientAddress).Property(p => p.POBox)
                .HasColumnName(nameof(Patient.PatientAddress.POBox));
            entityBuilder.Property(p => p.PatientGender)
                .HasConversion(v => v.ToString(), v => (Sex)Enum.Parse(typeof(Sex), v))
                .HasColumnName(nameof(Patient.PatientGender));
            entityBuilder.Property(p => p.PatientDateOfBirth)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientDateOfBirth));
            entityBuilder.OwnsOne(p => p.PatientIdentification).Property(p => p.PassportNo)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientIdentification.PassportNo));
            entityBuilder.OwnsOne(p => p.PatientIdentification).Property(p => p.EmirateId)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientIdentification.EmirateId));
            entityBuilder.Property(p => p.PatientWorkTitle)
                .HasColumnName(nameof(Patient.PatientWorkTitle));
            entityBuilder.OwnsOne(p => p.PatientContactInformation).Property(p => p.MailAddress)
                .HasColumnName(nameof(Patient.PatientContactInformation.MailAddress));
            entityBuilder.OwnsOne(p => p.PatientContactInformation).OwnsOne(p => p.Telephone).Property(p => p.Mobile)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientContactInformation.Telephone.Mobile));
            entityBuilder.OwnsOne(p => p.PatientContactInformation).OwnsOne(p => p.Telephone).Property(p => p.Home)
                .HasColumnName(nameof(Patient.PatientContactInformation.Telephone.Home));
            entityBuilder.OwnsOne(p => p.PatientContactInformation).OwnsOne(p => p.Telephone).Property(p => p.Work)
                .HasColumnName(nameof(Patient.PatientContactInformation.Telephone.Work));



            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianName).Property(p => p.FirstName)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianName.FirstName)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianName).Property(p => p.MidName)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianName.MidName)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianName).Property(p => p.LastName)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianName.LastName)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianName).Property(p => p.Suffix)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianName.Suffix)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianAddress).Property(p => p.AddressLine1)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianAddress.AddressLine1)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianAddress).Property(p => p.AddressLine2)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianAddress.AddressLine2)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianAddress).Property(p => p.POBox)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianAddress.POBox)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianTelephone).Property(p => p.Mobile)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianTelephone.Mobile)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianTelephone).Property(p => p.Home)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianTelephone.Home)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).OwnsOne(p => p.GuardianTelephone).Property(p => p.Work)
                .HasColumnName($"Guardian{nameof(Patient.PatientGuardian.GuardianTelephone.Work)}");
            entityBuilder.OwnsOne(p => p.PatientGuardian).Property(p => p.GuardianRelation)
                .HasConversion(v => v.ToString(), v => (Relation)Enum.Parse(typeof(Relation), v))
                .HasColumnName(nameof(Patient.PatientGuardian.GuardianRelation));
            
            entityBuilder.Property(p => p.PatientNationality)
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientNationality));
            entityBuilder.Property(p => p.PatientInsurance)
                .HasConversion(v => v.ToString(), v => (Insurance)Enum.Parse(typeof(Insurance), v))
                .IsRequired()
                .HasColumnName(nameof(Patient.PatientInsurance));
             entityBuilder.Property(p => p.PatientMaritalStatus)
                .HasConversion(v => v.ToString(), v => (MaritalStatus)Enum.Parse(typeof(MaritalStatus), v))
                .HasColumnName(nameof(Patient.PatientMaritalStatus));
            
            entityBuilder.ToTable(nameof(Patient));
        }
    }
}