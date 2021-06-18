using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SevkiyatStokTakipSistemi.Migrations
{
    public partial class Yapilandir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AracBilgileri",
                schema: "Identity",
                columns: table => new
                {
                    AracBilgisiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracPlakasi = table.Column<string>(nullable: false),
                    AracKapasitesi = table.Column<string>(nullable: false),
                    AracTipi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracBilgileri", x => x.AracBilgisiId);
                });

            migrationBuilder.CreateTable(
                name: "Firma",
                schema: "Identity",
                columns: table => new
                {
                    FirmaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriKodu = table.Column<int>(nullable: false),
                    Telnon = table.Column<int>(nullable: false),
                    CariIsim = table.Column<string>(nullable: true),
                    FirmaAdresi = table.Column<string>(nullable: true),
                    FirmaVergiNum = table.Column<int>(nullable: false),
                    FirmaVergiDairesi = table.Column<string>(nullable: true),
                    FirmaİlgiliKisi = table.Column<string>(nullable: true),
                    İlgiliKisiTel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sevkiyatlar",
                schema: "Identity",
                columns: table => new
                {
                    SevkiyatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurumBildir = table.Column<string>(nullable: true),
                    TeslimAlcakKisi = table.Column<string>(nullable: false),
                    TeslimKisiTelNo = table.Column<int>(nullable: false),
                    SevkYuklemeyiyapanKisi = table.Column<string>(nullable: false),
                    YuklemeYardimi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sevkiyatlar", x => x.SevkiyatId);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                schema: "Identity",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisAcıklama = table.Column<string>(nullable: true),
                    SiparisTarihi = table.Column<DateTime>(nullable: false),
                    TeslimTarihi = table.Column<DateTime>(nullable: false),
                    UrunMiktari = table.Column<string>(nullable: true),
                    Durum = table.Column<string>(nullable: true),
                    SevkAdresi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.SiparisId);
                });

            migrationBuilder.CreateTable(
                name: "Suruculer",
                schema: "Identity",
                columns: table => new
                {
                    SurucuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Telno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suruculer", x => x.SurucuId);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                schema: "Identity",
                columns: table => new
                {
                    UrunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunName = table.Column<string>(nullable: true),
                    UrunKodu = table.Column<string>(nullable: true),
                    UrunBirimi = table.Column<string>(nullable: true),
                    Resimyolu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.UrunId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Unvan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SevkiyatAraci",
                schema: "Identity",
                columns: table => new
                {
                    SevkiyatId = table.Column<int>(nullable: false),
                    AracBilgisiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SevkiyatAraci", x => new { x.SevkiyatId, x.AracBilgisiId });
                    table.ForeignKey(
                        name: "FK_SevkiyatAraci_AracBilgileri_AracBilgisiId",
                        column: x => x.AracBilgisiId,
                        principalSchema: "Identity",
                        principalTable: "AracBilgileri",
                        principalColumn: "AracBilgisiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SevkiyatAraci_Sevkiyatlar_SevkiyatId",
                        column: x => x.SevkiyatId,
                        principalSchema: "Identity",
                        principalTable: "Sevkiyatlar",
                        principalColumn: "SevkiyatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmaSiparisleri",
                schema: "Identity",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false),
                    FirmaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmaSiparisleri", x => new { x.FirmaId, x.SiparisId });
                    table.ForeignKey(
                        name: "FK_FirmaSiparisleri_Firma_FirmaId",
                        column: x => x.FirmaId,
                        principalSchema: "Identity",
                        principalTable: "Firma",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirmaSiparisleri_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalSchema: "Identity",
                        principalTable: "Siparisler",
                        principalColumn: "SiparisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SipSevkiyat",
                schema: "Identity",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false),
                    SevkiyatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SipSevkiyat", x => new { x.SevkiyatId, x.SiparisId });
                    table.ForeignKey(
                        name: "FK_SipSevkiyat_Sevkiyatlar_SevkiyatId",
                        column: x => x.SevkiyatId,
                        principalSchema: "Identity",
                        principalTable: "Sevkiyatlar",
                        principalColumn: "SevkiyatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SipSevkiyat_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalSchema: "Identity",
                        principalTable: "Siparisler",
                        principalColumn: "SiparisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AracSurucusu",
                schema: "Identity",
                columns: table => new
                {
                    AracBilgisiId = table.Column<int>(nullable: false),
                    SurucuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracSurucusu", x => new { x.SurucuId, x.AracBilgisiId });
                    table.ForeignKey(
                        name: "FK_AracSurucusu_AracBilgileri_AracBilgisiId",
                        column: x => x.AracBilgisiId,
                        principalSchema: "Identity",
                        principalTable: "AracBilgileri",
                        principalColumn: "AracBilgisiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracSurucusu_Suruculer_SurucuId",
                        column: x => x.SurucuId,
                        principalSchema: "Identity",
                        principalTable: "Suruculer",
                        principalColumn: "SurucuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoklar",
                schema: "Identity",
                columns: table => new
                {
                    StokId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokAdedi = table.Column<int>(nullable: false),
                    StokBirimi = table.Column<int>(nullable: false),
                    UrunForeingKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoklar", x => x.StokId);
                    table.ForeignKey(
                        name: "FK_Stoklar_Urun_UrunForeingKey",
                        column: x => x.UrunForeingKey,
                        principalSchema: "Identity",
                        principalTable: "Urun",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrunSiparisler",
                schema: "Identity",
                columns: table => new
                {
                    UrunId = table.Column<int>(nullable: false),
                    SiparisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunSiparisler", x => new { x.UrunId, x.SiparisId });
                    table.ForeignKey(
                        name: "FK_UrunSiparisler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalSchema: "Identity",
                        principalTable: "Siparisler",
                        principalColumn: "SiparisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunSiparisler_Urun_UrunId",
                        column: x => x.UrunId,
                        principalSchema: "Identity",
                        principalTable: "Urun",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AracSurucusu_AracBilgisiId",
                schema: "Identity",
                table: "AracSurucusu",
                column: "AracBilgisiId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaSiparisleri_SiparisId",
                schema: "Identity",
                table: "FirmaSiparisleri",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SevkiyatAraci_AracBilgisiId",
                schema: "Identity",
                table: "SevkiyatAraci",
                column: "AracBilgisiId");

            migrationBuilder.CreateIndex(
                name: "IX_SipSevkiyat_SiparisId",
                schema: "Identity",
                table: "SipSevkiyat",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoklar_UrunForeingKey",
                schema: "Identity",
                table: "Stoklar",
                column: "UrunForeingKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrunSiparisler_SiparisId",
                schema: "Identity",
                table: "UrunSiparisler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersClaims_UserId",
                schema: "Identity",
                table: "UsersClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracSurucusu",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FirmaSiparisleri",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SevkiyatAraci",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SipSevkiyat",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Stoklar",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UrunSiparisler",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Suruculer",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Firma",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AracBilgileri",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Sevkiyatlar",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Siparisler",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Urun",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");
        }
    }
}
