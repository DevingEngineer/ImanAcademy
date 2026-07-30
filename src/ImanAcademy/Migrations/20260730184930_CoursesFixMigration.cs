using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ImanAcademy.Migrations
{
    /// <inheritdoc />
    public partial class CoursesFixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "courses_category_id_fkey",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "courses_instructor_id_fkey",
                table: "courses");

            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "student_answers");

            migrationBuilder.DropTable(
                name: "quiz_attempts");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropPrimaryKey(
                name: "courses_pkey",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_instructor_id",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "difficulty_level",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "instructor_id",
                table: "courses");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Courses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Courses",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Courses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Courses",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Courses",
                newName: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_courses_category_id",
                table: "Courses",
                newName: "IX_Courses_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Courses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Courses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Courses",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "Tags",
                table: "Courses",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    EstimatedDurationMinutes = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.CourseId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    EstimatedDurationMinutes = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    EstimatedDurationMinutes = table.Column<int>(type: "integer", nullable: true),
                    IsFreePreview = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StepType = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PassingScorePercent = table.Column<int>(type: "integer", nullable: true),
                    AllowRetake = table.Column<bool>(type: "boolean", nullable: true),
                    TimeLimitSeconds = table.Column<int>(type: "integer", nullable: true),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    DurationSeconds = table.Column<int>(type: "integer", nullable: true),
                    CaptionsUrl = table.Column<string>(type: "text", nullable: true),
                    Transcript = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_SubModules_SubModuleId",
                        column: x => x.SubModuleId,
                        principalTable: "SubModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizStepId = table.Column<Guid>(type: "uuid", nullable: false),
                    Prompt = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "text", nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Steps_QuizStepId",
                        column: x => x.QuizStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentStepId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    MimeType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepAttachments_Steps_ContentStepId",
                        column: x => x.ContentStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Slug",
                table: "Courses",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_InstructorId",
                table: "CourseInstructor",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptions_QuizQuestionId",
                table: "QuizOptions",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizStepId",
                table: "QuizQuestions",
                column: "QuizStepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepAttachments_ContentStepId",
                table: "StepAttachments",
                column: "ContentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SubModuleId",
                table: "Steps",
                column: "SubModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubModules_ModuleId",
                table: "SubModules",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "QuizOptions");

            migrationBuilder.DropTable(
                name: "StepAttachments");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "SubModules");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Slug",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "courses");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "courses",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "courses",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "courses",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "courses",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "courses",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "courses",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryId",
                table: "courses",
                newName: "IX_courses_category_id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "courses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "courses",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "courses",
                type: "timestamp without time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "course_id",
                table: "courses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "difficulty_level",
                table: "courses",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "instructor_id",
                table: "courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "courses_pkey",
                table: "courses",
                column: "course_id");

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: true),
                    content_url = table.Column<string>(type: "text", nullable: true),
                    is_preview = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lessons_pkey", x => x.lesson_id);
                    table.ForeignKey(
                        name: "lessons_course_id_fkey",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bio = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    quiz_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lesson_id = table.Column<int>(type: "integer", nullable: true),
                    passing_score = table.Column<int>(type: "integer", nullable: true, defaultValue: 70),
                    time_limit_minutes = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quizzes_pkey", x => x.quiz_id);
                    table.ForeignKey(
                        name: "quizzes_lesson_id_fkey",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "lesson_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    enrollment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    progress_percent = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, defaultValueSql: "'active'::character varying")
                },
                constraints: table =>
                {
                    table.PrimaryKey("enrollments_pkey", x => x.enrollment_id);
                    table.ForeignKey(
                        name: "enrollments_course_id_fkey",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "enrollments_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    payment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    transaction_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("payments_pkey", x => x.payment_id);
                    table.ForeignKey(
                        name: "payments_course_id_fkey",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "payments_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    rating = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reviews_pkey", x => x.review_id);
                    table.ForeignKey(
                        name: "reviews_course_id_fkey",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "reviews_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quiz_id = table.Column<int>(type: "integer", nullable: true),
                    points = table.Column<int>(type: "integer", nullable: true, defaultValue: 1),
                    question_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("questions_pkey", x => x.question_id);
                    table.ForeignKey(
                        name: "questions_quiz_id_fkey",
                        column: x => x.quiz_id,
                        principalTable: "quizzes",
                        principalColumn: "quiz_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quiz_attempts",
                columns: table => new
                {
                    attempt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quiz_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    finished_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    score = table.Column<int>(type: "integer", nullable: true),
                    started_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quiz_attempts_pkey", x => x.attempt_id);
                    table.ForeignKey(
                        name: "quiz_attempts_quiz_id_fkey",
                        column: x => x.quiz_id,
                        principalTable: "quizzes",
                        principalColumn: "quiz_id");
                    table.ForeignKey(
                        name: "quiz_attempts_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    option_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    option_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("options_pkey", x => x.option_id);
                    table.ForeignKey(
                        name: "options_question_id_fkey",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_answers",
                columns: table => new
                {
                    answer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    attempt_id = table.Column<int>(type: "integer", nullable: true),
                    question_id = table.Column<int>(type: "integer", nullable: true),
                    selected_option_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("student_answers_pkey", x => x.answer_id);
                    table.ForeignKey(
                        name: "student_answers_attempt_id_fkey",
                        column: x => x.attempt_id,
                        principalTable: "quiz_attempts",
                        principalColumn: "attempt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "student_answers_question_id_fkey",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id");
                    table.ForeignKey(
                        name: "student_answers_selected_option_id_fkey",
                        column: x => x.selected_option_id,
                        principalTable: "options",
                        principalColumn: "option_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_instructor_id",
                table: "courses",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_course_id",
                table: "enrollments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_user_id",
                table: "enrollments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_course_id",
                table: "lessons",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_question_id",
                table: "options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_course_id",
                table: "payments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_user_id",
                table: "payments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "payments_transaction_id_key",
                table: "payments",
                column: "transaction_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_quiz_id",
                table: "questions",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_attempts_quiz_id",
                table: "quiz_attempts",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_attempts_user_id",
                table: "quiz_attempts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_lesson_id",
                table: "quizzes",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_course_id",
                table: "reviews",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_answers_attempt_id",
                table: "student_answers",
                column: "attempt_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_answers_question_id",
                table: "student_answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_answers_selected_option_id",
                table: "student_answers",
                column: "selected_option_id");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "courses_category_id_fkey",
                table: "courses",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id");

            migrationBuilder.AddForeignKey(
                name: "courses_instructor_id_fkey",
                table: "courses",
                column: "instructor_id",
                principalTable: "users",
                principalColumn: "user_id");
        }
    }
}
