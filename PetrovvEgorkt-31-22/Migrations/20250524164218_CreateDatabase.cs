using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetrovvEgorkt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_degree_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Название степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_position_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "Cathedrals",
                columns: table => new
                {
                    cathedral_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_cathedral_cathedralname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя кафедры"),
                    f_head_teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор заведующего кафедрой")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_cathedral_cathedral_id", x => x.cathedral_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Отчество преподавателя"),
                    f_cathedral_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры"),
                    f_academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени"),
                    f_position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_teacher_academic_degree",
                        column: x => x.f_academic_degree_id,
                        principalTable: "cd_academic_degree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_teacher_cathedral",
                        column: x => x.f_cathedral_id,
                        principalTable: "Cathedrals",
                        principalColumn: "cathedral_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_position",
                        column: x => x.f_position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    workload_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    f_discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины"),
                    c_lesson_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "Тип занятия (лекция/практика)"),
                    c_hours = table.Column<int>(type: "int", nullable: false, comment: "Количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workload_workload_id", x => x.workload_id);
                    table.ForeignKey(
                        name: "fk_workload_discipline",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_workload_teacher",
                        column: x => x.f_teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cathedrals_f_head_teacher_id",
                table: "Cathedrals",
                column: "f_head_teacher_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_f_academic_degree_id",
                table: "cd_teacher",
                column: "f_academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_f_cathedral_id",
                table: "cd_teacher",
                column: "f_cathedral_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_f_position_id",
                table: "cd_teacher",
                column: "f_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_workload_f_discipline_id",
                table: "cd_workload",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_workload_f_teacher_id",
                table: "cd_workload",
                column: "f_teacher_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cathedral_head_teacher",
                table: "Cathedrals",
                column: "f_head_teacher_id",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cathedral_head_teacher",
                table: "Cathedrals");

            migrationBuilder.DropTable(
                name: "cd_workload");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "Cathedrals");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
