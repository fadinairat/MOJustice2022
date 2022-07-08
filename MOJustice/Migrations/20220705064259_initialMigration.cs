using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOJustice.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogFor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogFor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryTypesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Types_Category_Types_CategoryTypesId",
                        column: x => x.CategoryTypesId,
                        principalTable: "Category_Types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ArTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HtmlTemplatesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlTemplatesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ArTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderBg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FooterColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MenuFontColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MenuFontHoverColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BodyColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitlesColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SummaryColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeftBoxColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ControlDefaultLang = table.Column<int>(type: "int", nullable: false),
                    WebDefaultLang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    LogFor = table.Column<int>(type: "int", nullable: false),
                    LogTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogDetails = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLogs_AdminLogFor_LogFor",
                        column: x => x.LogFor,
                        principalTable: "AdminLogFor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    ItemsPerPage = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    ShowAsMain = table.Column<bool>(type: "bit", nullable: false),
                    ShowInSiteMap = table.Column<bool>(type: "bit", nullable: false),
                    ShowDescription = table.Column<bool>(type: "bit", nullable: false),
                    ShowTitle = table.Column<bool>(type: "bit", nullable: false),
                    ShowThumb = table.Column<bool>(type: "bit", nullable: false),
                    ShowInPath = table.Column<bool>(type: "bit", nullable: false),
                    ShowInSearch = table.Column<bool>(type: "bit", nullable: false),
                    ShowDate = table.Column<bool>(type: "bit", nullable: false),
                    ShowInCatList = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Category_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Category_Types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryPage",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    PagesPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPage", x => new { x.CategoriesId, x.PagesPageId });
                    table.ForeignKey(
                        name: "FK_CategoryPage_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Parent = table.Column<int>(type: "int", nullable: false),
                    Publish = table.Column<byte>(type: "tinyint", nullable: false),
                    Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ShowHome = table.Column<byte>(type: "tinyint", nullable: false),
                    AllowComment = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Categories_CatId",
                        column: x => x.CatId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_FileType_Type",
                        column: x => x.Type,
                        principalTable: "FileType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesList_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    P1 = table.Column<bool>(type: "bit", nullable: false),
                    P2 = table.Column<bool>(type: "bit", nullable: false),
                    P3 = table.Column<bool>(type: "bit", nullable: false),
                    P4 = table.Column<bool>(type: "bit", nullable: false),
                    P5 = table.Column<bool>(type: "bit", nullable: false),
                    P6 = table.Column<bool>(type: "bit", nullable: false),
                    P7 = table.Column<bool>(type: "bit", nullable: false),
                    P8 = table.Column<bool>(type: "bit", nullable: false),
                    P9 = table.Column<bool>(type: "bit", nullable: false),
                    P10 = table.Column<bool>(type: "bit", nullable: false),
                    P11 = table.Column<bool>(type: "bit", nullable: false),
                    P12 = table.Column<bool>(type: "bit", nullable: false),
                    P13 = table.Column<bool>(type: "bit", nullable: false),
                    P14 = table.Column<bool>(type: "bit", nullable: false),
                    P15 = table.Column<bool>(type: "bit", nullable: false),
                    P16 = table.Column<bool>(type: "bit", nullable: false),
                    P17 = table.Column<bool>(type: "bit", nullable: false),
                    P18 = table.Column<bool>(type: "bit", nullable: false),
                    P20 = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<byte>(type: "tinyint", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HtmlTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HtmlTemplates_HtmlTemplatesTypes_Type",
                        column: x => x.Type,
                        principalTable: "HtmlTemplatesTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HtmlTemplates_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HtmlTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_MenuLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "MenuLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranslateId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RedirectUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Thumb2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShowThumb = table.Column<bool>(type: "bit", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AsMenu = table.Column<bool>(type: "bit", nullable: false),
                    ShowAsMain = table.Column<bool>(type: "bit", nullable: false),
                    Parent = table.Column<int>(type: "int", nullable: true),
                    ShowInSearchPage = table.Column<bool>(type: "bit", nullable: false),
                    ShowInSiteMap = table.Column<bool>(type: "bit", nullable: false),
                    ShowDate = table.Column<bool>(type: "bit", nullable: false),
                    AllowComment = table.Column<bool>(type: "bit", nullable: false),
                    ShowAsRelated = table.Column<bool>(type: "bit", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Gallery = table.Column<int>(type: "int", nullable: true),
                    ShowRelated = table.Column<bool>(type: "bit", nullable: false),
                    Sticky = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Archive = table.Column<bool>(type: "bit", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Video = table.Column<int>(type: "int", nullable: true),
                    Audio = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    LastEdit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                    table.ForeignKey(
                        name: "FK_Pages_HtmlTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "HtmlTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pages_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pages_Pages_Parent",
                        column: x => x.Parent,
                        principalTable: "Pages",
                        principalColumn: "PageId");
                    table.ForeignKey(
                        name: "FK_Pages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    TempId = table.Column<int>(type: "int", nullable: true),
                    ArName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ItemsPerPage = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_HtmlTemplates_TempId",
                        column: x => x.TempId,
                        principalTable: "HtmlTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PagesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagesCategories_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagesCategories_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagsRel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: true),
                    RelType = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsRel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagsRel_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TagsRel_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId");
                    table.ForeignKey(
                        name: "FK_TagsRel_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminLogs_LogFor",
                table: "AdminLogs",
                column: "LogFor");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLogs_UserId",
                table: "AdminLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LangId",
                table: "Categories",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TemplateId",
                table: "Categories",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeId",
                table: "Categories",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Types_CategoryTypesId",
                table: "Category_Types",
                column: "CategoryTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPage_PagesPageId",
                table: "CategoryPage",
                column: "PagesPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CatId",
                table: "Files",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_LangId",
                table: "Files",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Type",
                table: "Files",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FilesList_FileId",
                table: "FilesList",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LangId",
                table: "Groups",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserId",
                table: "Groups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlTemplates_LangId",
                table: "HtmlTemplates",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlTemplates_Type",
                table: "HtmlTemplates",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlTemplates_UserId",
                table: "HtmlTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_LangId",
                table: "Menus",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_LocationId",
                table: "Menus",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_UserId",
                table: "Menus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_LangId",
                table: "Pages",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Parent",
                table: "Pages",
                column: "Parent");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_TemplateId",
                table: "Pages",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserId",
                table: "Pages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesCategories_CategoryId",
                table: "PagesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesCategories_LangId",
                table: "PagesCategories",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesCategories_PageId",
                table: "PagesCategories",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LangId",
                table: "Tags",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TempId",
                table: "Tags",
                column: "TempId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsRel_LangId",
                table: "TagsRel",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsRel_PageId",
                table: "TagsRel",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsRel_TagId",
                table: "TagsRel",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddedBy",
                table: "Users",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LangId",
                table: "Users",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminLogs_Users_UserId",
                table: "AdminLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_HtmlTemplates_TemplateId",
                table: "Categories",
                column: "TemplateId",
                principalTable: "HtmlTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPage_Pages_PagesPageId",
                table: "CategoryPage",
                column: "PagesPageId",
                principalTable: "Pages",
                principalColumn: "PageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_UserId",
                table: "Groups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_UserId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "AdminLogs");

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
                name: "CategoryPage");

            migrationBuilder.DropTable(
                name: "FilesList");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "PagesCategories");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "TagsRel");

            migrationBuilder.DropTable(
                name: "AdminLogFor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "MenuLocations");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "Category_Types");

            migrationBuilder.DropTable(
                name: "HtmlTemplates");

            migrationBuilder.DropTable(
                name: "HtmlTemplatesTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
