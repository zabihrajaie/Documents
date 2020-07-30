using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DocumentType");

            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyOnChange",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Scopes",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    IsInterface = table.Column<bool>(nullable: false),
                    OwnerDataType = table.Column<bool>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    ScopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScopeDocumentType",
                        column: x => x.ScopeId,
                        principalSchema: "DocumentType",
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DomainScope",
                schema: "DocumentType",
                columns: table => new
                {
                    Domains_Id = table.Column<int>(nullable: false),
                    Scopes_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainScope", x => new { x.Domains_Id, x.Scopes_Id });
                    table.ForeignKey(
                        name: "FK_DomainScope_Domain",
                        column: x => x.Domains_Id,
                        principalSchema: "DocumentType",
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainScope_Scope",
                        column: x => x.Scopes_Id,
                        principalSchema: "DocumentType",
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<long>(nullable: false),
                    AllowNull = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeAttribute",
                        column: x => x.DocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquiryId = table.Column<long>(nullable: false),
                    FullInquiryId = table.Column<string>(maxLength: 21, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAsJson = table.Column<string>(nullable: false),
                    ImageId = table.Column<string>(maxLength: 50, nullable: false),
                    RegistrationUserId = table.Column<string>(maxLength: 50, nullable: false),
                    DocumentTypeId = table.Column<long>(nullable: false),
                    AllowChange = table.Column<bool>(nullable: false),
                    NextVersion = table.Column<string>(maxLength: 21, nullable: true),
                    PrevVersion = table.Column<string>(maxLength: 21, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeDocument",
                        column: x => x.DocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HasA1",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRequired = table.Column<bool>(nullable: false),
                    ParrentDocumentTypeId = table.Column<long>(nullable: false),
                    ChildDocumentTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasA1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeHasA12",
                        column: x => x.ChildDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTypeHasA11",
                        column: x => x.ParrentDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HasANs",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinParticipation = table.Column<int>(nullable: false),
                    MaxParticipation = table.Column<int>(nullable: false),
                    ParentDocumentTypeId = table.Column<long>(nullable: false),
                    ChildDocumentTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeHasA1",
                        column: x => x.ChildDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTypeHasA",
                        column: x => x.ParentDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IsAs",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperDocumentTypeId = table.Column<long>(nullable: false),
                    SubDocumentTypeId = table.Column<long>(nullable: false),
                    SubDocumentType_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeIsA",
                        column: x => x.SubDocumentType_Id,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTypeIsA1",
                        column: x => x.SuperDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedToes",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RightSideAttributes = table.Column<string>(nullable: true),
                    LeftSideAttributes = table.Column<string>(nullable: true),
                    IsCausal = table.Column<bool>(nullable: false),
                    MinParticipation = table.Column<int>(nullable: false),
                    MaxParticipation = table.Column<int>(nullable: false),
                    RightDocumentTypeId = table.Column<long>(nullable: false),
                    LeftDocumentTypeId = table.Column<long>(nullable: false),
                    PolicyOnChangeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedToes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeRelatedTo1",
                        column: x => x.LeftDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTypeRelatedTo",
                        column: x => x.RightDocumentTypeId,
                        principalSchema: "DocumentType",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocEvents",
                schema: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<long>(nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEvent",
                        column: x => x.DocumentId,
                        principalSchema: "DocumentType",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeAttribute",
                schema: "DocumentType",
                table: "Attributes",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentEvent",
                schema: "DocumentType",
                table: "DocEvents",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_EventUser",
                schema: "DocumentType",
                table: "DocEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeDocument",
                schema: "DocumentType",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ScopeDocumentType",
                schema: "DocumentType",
                table: "DocumentTypes",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DomainScope_Scope",
                schema: "DocumentType",
                table: "DomainScope",
                column: "Scopes_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeHasA12",
                schema: "DocumentType",
                table: "HasA1",
                column: "ChildDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeHasA11",
                schema: "DocumentType",
                table: "HasA1",
                column: "ParrentDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeHasA1",
                schema: "DocumentType",
                table: "HasANs",
                column: "ChildDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeHasA",
                schema: "DocumentType",
                table: "HasANs",
                column: "ParentDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeIsA",
                schema: "DocumentType",
                table: "IsAs",
                column: "SubDocumentType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeIsA1",
                schema: "DocumentType",
                table: "IsAs",
                column: "SuperDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeRelatedTo1",
                schema: "DocumentType",
                table: "RelatedToes",
                column: "LeftDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DocumentTypeRelatedTo",
                schema: "DocumentType",
                table: "RelatedToes",
                column: "RightDocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "AttributeTypes",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "DocEvents",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "DomainScope",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "HasA1",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "HasANs",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "IsAs",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "PolicyOnChange",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "RelatedToes",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "Domains",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "DocumentType");

            migrationBuilder.DropTable(
                name: "Scopes",
                schema: "DocumentType");
        }
    }
}
