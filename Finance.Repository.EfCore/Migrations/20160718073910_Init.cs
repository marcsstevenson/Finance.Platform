using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Finance.Repository.EfCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankAccountName = table.Column<string>(nullable: true),
                    BankAccountNumber = table.Column<string>(nullable: true),
                    BankBranchName = table.Column<string>(nullable: true),
                    BankingCompany = table.Column<string>(nullable: true),
                    CellArea = table.Column<string>(nullable: true),
                    CellCountry = table.Column<string>(nullable: true),
                    CellNumber = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DriversLicenceNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FaxArea = table.Column<string>(nullable: true),
                    FaxCountry = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    PhoneArea = table.Column<string>(nullable: true),
                    PhoneCountry = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SkypeName = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankAccountName = table.Column<string>(nullable: true),
                    BankAccountNumber = table.Column<string>(nullable: true),
                    BankBranchName = table.Column<string>(nullable: true),
                    BankingCompany = table.Column<string>(nullable: true),
                    CellArea = table.Column<string>(nullable: true),
                    CellCountry = table.Column<string>(nullable: true),
                    CellNumber = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FaxArea = table.Column<string>(nullable: true),
                    FaxCountry = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneArea = table.Column<string>(nullable: true),
                    PhoneCountry = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "CustomerStreetAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OtherInformation = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStreetAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerStreetAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DealershipId = table.Column<Guid>(nullable: true),
                    EnteredBy = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerNote_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerNote_Dealership_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealershipStreetAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DealershipId = table.Column<Guid>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OtherInformation = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealershipStreetAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealershipStreetAddress_Dealership_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssignedToId = table.Column<Guid>(nullable: true),
                    CashManagerReference = table.Column<int>(nullable: false),
                    Commission = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DealStatus = table.Column<int>(nullable: false),
                    DealershipClawbackNotes = table.Column<decimal>(nullable: false),
                    DealershipCommission = table.Column<decimal>(nullable: false),
                    DocumentationFee = table.Column<decimal>(nullable: false),
                    FinanceCompanyId = table.Column<Guid>(nullable: true),
                    FinanceVolume = table.Column<decimal>(nullable: false),
                    GuaranteedAssetProtection = table.Column<decimal>(nullable: false),
                    MechanicalBreakDownInsurance = table.Column<decimal>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    OtherInsurance = table.Column<decimal>(nullable: false),
                    OtherInsuranceNote = table.Column<string>(nullable: true),
                    PaymentProtectionInsurance = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    SecurityDescription = table.Column<string>(nullable: true),
                    SourceId = table.Column<Guid>(nullable: true),
                    TermInMonths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deal_StaffMember_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "StaffMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deal_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deal_FinanceCompany_FinanceCompanyId",
                        column: x => x.FinanceCompanyId,
                        principalTable: "FinanceCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deal_Dealership_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Dealership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DealNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DealId = table.Column<Guid>(nullable: false),
                    EnteredBy = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealNote_Deal_DealId",
                        column: x => x.DealId,
                        principalTable: "Deal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNote_CustomerId",
                table: "CustomerNote",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNote_DealershipId",
                table: "CustomerNote",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerStreetAddress_CustomerId",
                table: "CustomerStreetAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealershipStreetAddress_DealershipId",
                table: "DealershipStreetAddress",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_AssignedToId",
                table: "Deal",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_CustomerId",
                table: "Deal",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_FinanceCompanyId",
                table: "Deal",
                column: "FinanceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_SourceId",
                table: "Deal",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DealNote_DealId",
                table: "DealNote",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerNote");

            migrationBuilder.DropTable(
                name: "CustomerStreetAddress");

            migrationBuilder.DropTable(
                name: "DealershipStreetAddress");

            migrationBuilder.DropTable(
                name: "DealNote");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StaffMember");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "FinanceCompany");

            migrationBuilder.DropTable(
                name: "Dealership");
        }
    }
}
