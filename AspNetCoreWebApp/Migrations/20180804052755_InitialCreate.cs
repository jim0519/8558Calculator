using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Cookie = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    Netmask = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Gateway = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    IPAddress = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    UserAgent = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    GeoLatitude = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    GeoLongitude = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AutoPostAdHeader",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPostAdHeader", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldGroup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataField",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFieldName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataField", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleRule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: false),
                    IntervalDay = table.Column<int>(nullable: false),
                    LastSuccessTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditBy = table.Column<string>(unicode: false, maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTask",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Seconds = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    StopOnError = table.Column<bool>(nullable: false),
                    LastStartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastEndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastSuccessTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTask", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SKUMapping",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OldSKU = table.Column<string>(maxLength: 500, nullable: true),
                    NewSKU = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUMapping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemplateName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AutoPostAdLine",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeaderID = table.Column<int>(nullable: false),
                    ExternalID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPostAdLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutoPostAdLine_AutoPostAdHeader",
                        column: x => x.HeaderID,
                        principalTable: "AutoPostAdHeader",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldLine",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldGroupID = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    FieldValue = table.Column<string>(unicode: false, maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomFieldLine_CustomFieldGroup",
                        column: x => x.CustomFieldGroupID,
                        principalTable: "CustomFieldGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoPostAdPostData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    InventoryQty = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    AccountID = table.Column<int>(nullable: false),
                    CustomFieldGroupID = table.Column<int>(nullable: false),
                    BusinessLogoPath = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: false),
                    ImagesPath = table.Column<string>(unicode: false, nullable: false),
                    CustomID = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Postage = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(unicode: false, nullable: false),
                    AdTypeID = table.Column<int>(nullable: false),
                    ScheduleRuleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPostAdPostData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutoPostAdPostData_Account",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoPostAdPostData_Address",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoPostAdPostData_CustomFieldGroup",
                        column: x => x.CustomFieldGroupID,
                        principalTable: "CustomFieldGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoPostAdPostData_ScheduleRule",
                        column: x => x.ScheduleRuleID,
                        principalTable: "ScheduleRule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleRuleLine",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleRuleID = table.Column<int>(nullable: false),
                    TimeRangeFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    TimeRangeTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditBy = table.Column<string>(unicode: false, maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRuleLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduleRuleLine_ScheduleRule",
                        column: x => x.ScheduleRuleID,
                        principalTable: "ScheduleRule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ParentCategoryID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TemplateID = table.Column<int>(nullable: false),
                    CategoryTypeID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Template",
                        column: x => x.TemplateID,
                        principalTable: "Template",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateField",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemplateID = table.Column<int>(nullable: false),
                    DataFieldID = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TemplateFieldName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    TemplateFieldType = table.Column<int>(nullable: false),
                    IsRequireInput = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateField", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateField_DataField",
                        column: x => x.DataFieldID,
                        principalTable: "DataField",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateField_Template",
                        column: x => x.TemplateID,
                        principalTable: "Template",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoPostAdResult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoPostAdDataID = table.Column<int>(nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AdID = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPostAdResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutoPostAdResult_AutoPostAdPostData",
                        column: x => x.AutoPostAdDataID,
                        principalTable: "AutoPostAdPostData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdLine_HeaderID",
                table: "AutoPostAdLine",
                column: "HeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdPostData_AccountID",
                table: "AutoPostAdPostData",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdPostData_AddressID",
                table: "AutoPostAdPostData",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdPostData_CategoryID",
                table: "AutoPostAdPostData",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdPostData_CustomFieldGroupID",
                table: "AutoPostAdPostData",
                column: "CustomFieldGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdPostData_ScheduleRuleID",
                table: "AutoPostAdPostData",
                column: "ScheduleRuleID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPostAdResult_AutoPostAdDataID",
                table: "AutoPostAdResult",
                column: "AutoPostAdDataID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldLine_CustomFieldGroupID",
                table: "CustomFieldLine",
                column: "CustomFieldGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryID",
                table: "ProductCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ParentCategoryID",
                table: "ProductCategory",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_TemplateID",
                table: "ProductCategory",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRuleLine_ScheduleRuleID",
                table: "ScheduleRuleLine",
                column: "ScheduleRuleID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateField_DataFieldID",
                table: "TemplateField",
                column: "DataFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateField_TemplateID",
                table: "TemplateField",
                column: "TemplateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoPostAdLine");

            migrationBuilder.DropTable(
                name: "AutoPostAdResult");

            migrationBuilder.DropTable(
                name: "CustomFieldLine");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ScheduleRuleLine");

            migrationBuilder.DropTable(
                name: "ScheduleTask");

            migrationBuilder.DropTable(
                name: "SKUMapping");

            migrationBuilder.DropTable(
                name: "TemplateField");

            migrationBuilder.DropTable(
                name: "AutoPostAdHeader");

            migrationBuilder.DropTable(
                name: "AutoPostAdPostData");

            migrationBuilder.DropTable(
                name: "DataField");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CustomFieldGroup");

            migrationBuilder.DropTable(
                name: "ScheduleRule");
        }
    }
}
