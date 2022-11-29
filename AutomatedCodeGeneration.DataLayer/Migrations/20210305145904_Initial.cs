using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedCodeGeneration.DataLayer.Migrations;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ActorModel",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ActorModel", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Systems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BeenGenerated = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Systems", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Classes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Access = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Classes", x => x.Id);
                table.ForeignKey(
                    name: "FK_Classes_Systems_SystemId",
                    column: x => x.SystemId,
                    principalTable: "Systems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "UseCaseModel",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                FK_UseCase_Extends = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                FK_UseCase_Includes = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UseCaseModel", x => x.Id);
                table.ForeignKey(
                    name: "FK_UseCaseModel_ActorModel_ActorId",
                    column: x => x.ActorId,
                    principalTable: "ActorModel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_UseCaseModel_Systems_SystemId",
                    column: x => x.SystemId,
                    principalTable: "Systems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_UseCaseModel_UseCaseModel_FK_UseCase_Extends",
                    column: x => x.FK_UseCase_Extends,
                    principalTable: "UseCaseModel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_UseCaseModel_UseCaseModel_FK_UseCase_Includes",
                    column: x => x.FK_UseCase_Includes,
                    principalTable: "UseCaseModel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ClassDataModel",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                NameTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Access = table.Column<int>(type: "int", nullable: false),
                ClassModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClassDataModel", x => x.Id);
                table.ForeignKey(
                    name: "FK_ClassDataModel_Classes_ClassModelId",
                    column: x => x.ClassModelId,
                    principalTable: "Classes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ClassMethodModel",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                NameTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Access = table.Column<int>(type: "int", nullable: false),
                ClassModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClassMethodModel", x => x.Id);
                table.ForeignKey(
                    name: "FK_ClassMethodModel_Classes_ClassModelId",
                    column: x => x.ClassModelId,
                    principalTable: "Classes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "NameTypeModel",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsStatic = table.Column<bool>(type: "bit", nullable: false),
                ClassMethodModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_NameTypeModel", x => x.Id);
                table.ForeignKey(
                    name: "FK_NameTypeModel_ClassMethodModel_ClassMethodModelId",
                    column: x => x.ClassMethodModelId,
                    principalTable: "ClassMethodModel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ClassDataModel_ClassModelId",
            table: "ClassDataModel",
            column: "ClassModelId");

        migrationBuilder.CreateIndex(
            name: "IX_ClassDataModel_NameTypeId",
            table: "ClassDataModel",
            column: "NameTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Classes_SystemId",
            table: "Classes",
            column: "SystemId");

        migrationBuilder.CreateIndex(
            name: "IX_ClassMethodModel_ClassModelId",
            table: "ClassMethodModel",
            column: "ClassModelId");

        migrationBuilder.CreateIndex(
            name: "IX_ClassMethodModel_NameTypeId",
            table: "ClassMethodModel",
            column: "NameTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_NameTypeModel_ClassMethodModelId",
            table: "NameTypeModel",
            column: "ClassMethodModelId");

        migrationBuilder.CreateIndex(
            name: "IX_UseCaseModel_ActorId",
            table: "UseCaseModel",
            column: "ActorId");

        migrationBuilder.CreateIndex(
            name: "IX_UseCaseModel_FK_UseCase_Extends",
            table: "UseCaseModel",
            column: "FK_UseCase_Extends");

        migrationBuilder.CreateIndex(
            name: "IX_UseCaseModel_FK_UseCase_Includes",
            table: "UseCaseModel",
            column: "FK_UseCase_Includes");

        migrationBuilder.CreateIndex(
            name: "IX_UseCaseModel_SystemId",
            table: "UseCaseModel",
            column: "SystemId");

        migrationBuilder.AddForeignKey(
            name: "FK_ClassDataModel_NameTypeModel_NameTypeId",
            table: "ClassDataModel",
            column: "NameTypeId",
            principalTable: "NameTypeModel",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_ClassMethodModel_NameTypeModel_NameTypeId",
            table: "ClassMethodModel",
            column: "NameTypeId",
            principalTable: "NameTypeModel",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_ClassMethodModel_Classes_ClassModelId",
            table: "ClassMethodModel");

        migrationBuilder.DropForeignKey(
            name: "FK_ClassMethodModel_NameTypeModel_NameTypeId",
            table: "ClassMethodModel");

        migrationBuilder.DropTable(
            name: "ClassDataModel");

        migrationBuilder.DropTable(
            name: "UseCaseModel");

        migrationBuilder.DropTable(
            name: "ActorModel");

        migrationBuilder.DropTable(
            name: "Classes");

        migrationBuilder.DropTable(
            name: "Systems");

        migrationBuilder.DropTable(
            name: "NameTypeModel");

        migrationBuilder.DropTable(
            name: "ClassMethodModel");
    }
}
