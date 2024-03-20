using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mc2.CrudTest.Core.Domain.Entities;
using Mc2.CrudTest.Core.Domain.ValueObjects;

namespace Mc2.Crud.Persistanse.Config;
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.OwnsOne(customer => customer.FirstName, firstNameBuilder =>
            {
                firstNameBuilder.WithOwner();

                firstNameBuilder.Property(firstName => firstName.Value)
                    .HasColumnName(nameof(Customer.FirstName))
                    .HasMaxLength(FirstName.MaxLenght)

                    .IsRequired();

            });
            builder.OwnsOne(customer => customer.LastName, lastNameBuilder =>
            {
                lastNameBuilder.WithOwner();

                lastNameBuilder.Property(lastName => lastName.Value)
                    .HasColumnName(nameof(Customer.LastName))
                    .HasMaxLength(LastName.MaxLenght)
                    .IsRequired();
            });
            builder.OwnsOne(customer => customer.Email, emailBuilder =>
            {
                emailBuilder.WithOwner();

                emailBuilder.Property(email => email.Value)
                    .HasColumnName(nameof(Customer.Email))
                    .HasMaxLength(Email.MaxLength)
                    .IsRequired();
            });
            builder.OwnsOne(customer => customer.AccountNumber, emailBuilder =>
            {
                emailBuilder.WithOwner();

                emailBuilder.Property(AccountNumber => AccountNumber.Value)
                    .HasColumnName(nameof(Customer.AccountNumber))
                    .IsRequired();
            });
            builder.OwnsOne(customer => customer.DateOfBirth, emailBuilder =>
            {
                emailBuilder.WithOwner();

                emailBuilder.Property(DateOfBirth => DateOfBirth.Value)
                    .HasColumnName(nameof(Customer.DateOfBirth))
                    .HasMaxLength(10)
                    .IsRequired();
            });
            builder.OwnsOne(customer => customer.PhoneNumber, emailBuilder =>
            {
                emailBuilder.WithOwner();

                emailBuilder.Property(PhoneNumber => PhoneNumber.Value)
                    .HasColumnName(nameof(Customer.PhoneNumber))
                    .HasMaxLength(13)

                    .IsRequired();
            });
            builder.Property<string>("FullName")
                .HasComputedColumnSql("CONCAT(FirstName, '-', LastName, '-', DateOfBirth)")
                .HasColumnName("FullName")
                .ValueGeneratedOnAddOrUpdate()
                .HasMaxLength(255)
            .IsRequired();
            // Create a unique index on the computed column
            builder.HasIndex("FullName").IsUnique();
            //builder.Property(user => user.IsDeleted).HasDefaultValue(false);
            //builder.HasQueryFilter(user => !user.IsDeleted);

            //other config to less mvarchar column and ....
//            builder.Property<string> ("CreatedBy")
        }
        //other config
    }
//    public abstract class AuditableDbEntity : IDbEntity
//    {
//        public string CreatedBy { get; set; } = default!;
//
//        public DateTime CreatedUtc { get; set; }
//
//        public string? LastModifiedBy { get; set; }
//
//        public DateTime? LastModifiedUtc { get; set; }
//    }
