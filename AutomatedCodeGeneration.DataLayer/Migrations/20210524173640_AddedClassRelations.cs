using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedCodeGeneration.DataLayer.Migrations
{
    public partial class AddedClassRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseModel_ActorModel_ActorId",
                table: "UseCaseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseModel_Systems_SystemId",
                table: "UseCaseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseModel_UseCaseModel_FK_UseCase_Extends",
                table: "UseCaseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseModel_UseCaseModel_FK_UseCase_Includes",
                table: "UseCaseModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UseCaseModel",
                table: "UseCaseModel");

            migrationBuilder.DropColumn(
                name: "Namespace",
                table: "NameTypeModel");

            migrationBuilder.RenameTable(
                name: "UseCaseModel",
                newName: "UseCases");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseModel_SystemId",
                table: "UseCases",
                newName: "IX_UseCases_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseModel_FK_UseCase_Includes",
                table: "UseCases",
                newName: "IX_UseCases_FK_UseCase_Includes");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseModel_FK_UseCase_Extends",
                table: "UseCases",
                newName: "IX_UseCases_FK_UseCase_Extends");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseModel_ActorId",
                table: "UseCases",
                newName: "IX_UseCases_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UseCases",
                table: "UseCases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClassRelationModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRelationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRelationModel_Classes_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRelationModel_TargetId",
                table: "ClassRelationModel",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_UseCases_ActorModel_ActorId",
                table: "UseCases",
                column: "ActorId",
                principalTable: "ActorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCases_Systems_SystemId",
                table: "UseCases",
                column: "SystemId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCases_UseCases_FK_UseCase_Extends",
                table: "UseCases",
                column: "FK_UseCase_Extends",
                principalTable: "UseCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCases_UseCases_FK_UseCase_Includes",
                table: "UseCases",
                column: "FK_UseCase_Includes",
                principalTable: "UseCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UseCases_ActorModel_ActorId",
                table: "UseCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCases_Systems_SystemId",
                table: "UseCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCases_UseCases_FK_UseCase_Extends",
                table: "UseCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCases_UseCases_FK_UseCase_Includes",
                table: "UseCases");

            migrationBuilder.DropTable(
                name: "ClassRelationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UseCases",
                table: "UseCases");

            migrationBuilder.RenameTable(
                name: "UseCases",
                newName: "UseCaseModel");

            migrationBuilder.RenameIndex(
                name: "IX_UseCases_SystemId",
                table: "UseCaseModel",
                newName: "IX_UseCaseModel_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_UseCases_FK_UseCase_Includes",
                table: "UseCaseModel",
                newName: "IX_UseCaseModel_FK_UseCase_Includes");

            migrationBuilder.RenameIndex(
                name: "IX_UseCases_FK_UseCase_Extends",
                table: "UseCaseModel",
                newName: "IX_UseCaseModel_FK_UseCase_Extends");

            migrationBuilder.RenameIndex(
                name: "IX_UseCases_ActorId",
                table: "UseCaseModel",
                newName: "IX_UseCaseModel_ActorId");

            migrationBuilder.AddColumn<string>(
                name: "Namespace",
                table: "NameTypeModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UseCaseModel",
                table: "UseCaseModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseModel_ActorModel_ActorId",
                table: "UseCaseModel",
                column: "ActorId",
                principalTable: "ActorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseModel_Systems_SystemId",
                table: "UseCaseModel",
                column: "SystemId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseModel_UseCaseModel_FK_UseCase_Extends",
                table: "UseCaseModel",
                column: "FK_UseCase_Extends",
                principalTable: "UseCaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseModel_UseCaseModel_FK_UseCase_Includes",
                table: "UseCaseModel",
                column: "FK_UseCase_Includes",
                principalTable: "UseCaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
