using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Finance.Repository.EfCore.Context;

namespace Finance.Repository.EfCore.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20160718073910_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Finance.Logic.Crm.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankAccountName");

                    b.Property<string>("BankAccountNumber");

                    b.Property<string>("BankBranchName");

                    b.Property<string>("BankingCompany");

                    b.Property<string>("CellArea");

                    b.Property<string>("CellCountry");

                    b.Property<string>("CellNumber");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("DriversLicenceNumber");

                    b.Property<string>("Email");

                    b.Property<string>("FaxArea");

                    b.Property<string>("FaxCountry");

                    b.Property<string>("FaxNumber");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int?>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("Number");

                    b.Property<string>("PhoneArea");

                    b.Property<string>("PhoneCountry");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("SkypeName");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Finance.Logic.Crm.CustomerNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid?>("DealershipId");

                    b.Property<string>("EnteredBy");

                    b.Property<string>("Note")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DealershipId");

                    b.ToTable("CustomerNote");
                });

            modelBuilder.Entity("Finance.Logic.Crm.CustomerStreetAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("City");

                    b.Property<string>("ContactPhoneNumber");

                    b.Property<Guid?>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name");

                    b.Property<string>("OtherInformation");

                    b.Property<string>("Postcode");

                    b.Property<string>("Region");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerStreetAddress");
                });

            modelBuilder.Entity("Finance.Logic.Crm.Dealership", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankAccountName");

                    b.Property<string>("BankAccountNumber");

                    b.Property<string>("BankBranchName");

                    b.Property<string>("BankingCompany");

                    b.Property<string>("CellArea");

                    b.Property<string>("CellCountry");

                    b.Property<string>("CellNumber");

                    b.Property<string>("ContactName");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("FaxArea");

                    b.Property<string>("FaxCountry");

                    b.Property<string>("FaxNumber");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneArea");

                    b.Property<string>("PhoneCountry");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Dealership");
                });

            modelBuilder.Entity("Finance.Logic.Crm.DealershipStreetAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("City");

                    b.Property<string>("ContactPhoneNumber");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid?>("DealershipId")
                        .IsRequired();

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name");

                    b.Property<string>("OtherInformation");

                    b.Property<string>("Postcode");

                    b.Property<string>("Region");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DealershipId");

                    b.ToTable("DealershipStreetAddress");
                });

            modelBuilder.Entity("Finance.Logic.Deals.Deal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssignedToId");

                    b.Property<int>("CashManagerReference");

                    b.Property<decimal>("Commission");

                    b.Property<Guid?>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("DealStatus");

                    b.Property<decimal>("DealershipClawbackNotes");

                    b.Property<decimal>("DealershipCommission");

                    b.Property<decimal>("DocumentationFee");

                    b.Property<Guid?>("FinanceCompanyId");

                    b.Property<decimal>("FinanceVolume");

                    b.Property<decimal>("GuaranteedAssetProtection");

                    b.Property<decimal>("MechanicalBreakDownInsurance");

                    b.Property<int>("Number");

                    b.Property<decimal>("OtherInsurance");

                    b.Property<string>("OtherInsuranceNote");

                    b.Property<decimal>("PaymentProtectionInsurance");

                    b.Property<decimal>("Rate");

                    b.Property<string>("SecurityDescription");

                    b.Property<Guid?>("SourceId");

                    b.Property<int>("TermInMonths");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FinanceCompanyId");

                    b.HasIndex("SourceId");

                    b.ToTable("Deal");
                });

            modelBuilder.Entity("Finance.Logic.Deals.DealNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid?>("DealId")
                        .IsRequired();

                    b.Property<string>("EnteredBy");

                    b.Property<string>("Note")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.ToTable("DealNote");
                });

            modelBuilder.Entity("Finance.Logic.FinanceCompanies.FinanceCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("FinanceCompany");
                });

            modelBuilder.Entity("Finance.Logic.Internal.StaffMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("StaffMember");
                });

            modelBuilder.Entity("Finance.Repository.EfCore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Finance.Logic.Crm.CustomerNote", b =>
                {
                    b.HasOne("Finance.Logic.Crm.Customer", "Customer")
                        .WithMany("CustomerNotes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Finance.Logic.Crm.Dealership")
                        .WithMany("CustomerNotes")
                        .HasForeignKey("DealershipId");
                });

            modelBuilder.Entity("Finance.Logic.Crm.CustomerStreetAddress", b =>
                {
                    b.HasOne("Finance.Logic.Crm.Customer", "Customer")
                        .WithMany("CustomerStreetAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Finance.Logic.Crm.DealershipStreetAddress", b =>
                {
                    b.HasOne("Finance.Logic.Crm.Dealership", "Dealership")
                        .WithMany("DealershipStreetAddresses")
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Finance.Logic.Deals.Deal", b =>
                {
                    b.HasOne("Finance.Logic.Internal.StaffMember", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId");

                    b.HasOne("Finance.Logic.Crm.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Finance.Logic.FinanceCompanies.FinanceCompany", "FinanceCompany")
                        .WithMany()
                        .HasForeignKey("FinanceCompanyId");

                    b.HasOne("Finance.Logic.Crm.Dealership", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");
                });

            modelBuilder.Entity("Finance.Logic.Deals.DealNote", b =>
                {
                    b.HasOne("Finance.Logic.Deals.Deal", "Deal")
                        .WithMany("DealNotes")
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Finance.Repository.EfCore.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Finance.Repository.EfCore.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Finance.Repository.EfCore.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
