namespace RegisterSubjectAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id_course = c.Int(nullable: false, identity: true),
                        faculty = c.String(nullable: false, maxLength: 255),
                        id_subject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_course)
                .ForeignKey("dbo.Subjects", t => t.id_subject)
                .Index(t => t.id_subject);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        id_subject = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        code = c.String(maxLength: 255),
                        credit = c.String(maxLength: 255),
                        start_day = c.DateTime(nullable: false),
                        end_day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_subject);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id_schedule = c.Int(nullable: false, identity: true),
                        id_subject = c.Int(nullable: false),
                        id_user = c.Int(nullable: false),
                        id_grade = c.Int(nullable: false),
                        open_day = c.DateTime(nullable: false),
                        close_day = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_schedule)
                .ForeignKey("dbo.Grades", t => t.id_grade)
                .ForeignKey("dbo.Subjects", t => t.id_subject)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_subject)
                .Index(t => t.id_user)
                .Index(t => t.id_grade);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        id_grade = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_grade);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id_user = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        fullname = c.String(nullable: false, maxLength: 255),
                        phoneNumber = c.String(maxLength: 255),
                        address = c.String(nullable: false, maxLength: 255),
                        gender = c.Int(nullable: false),
                        birthday = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        id_role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_user)
                .ForeignKey("dbo.Roles", t => t.id_role)
                .Index(t => t.id_role);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id_role = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_role);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        id_score = c.Int(nullable: false, identity: true),
                        id_subject = c.Int(nullable: false),
                        id_user = c.Int(nullable: false),
                        mark = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id_score)
                .ForeignKey("dbo.Subjects", t => t.id_subject)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_subject)
                .Index(t => t.id_user);
            
            CreateTable(
                "dbo.ScheduleStudents",
                c => new
                    {
                        id_student = c.Int(nullable: false),
                        id_schedule = c.Int(nullable: false),
                        User_id_user = c.Int(),
                    })
                .PrimaryKey(t => new { t.id_student, t.id_schedule })
                .ForeignKey("dbo.Schedules", t => t.id_schedule)
                .ForeignKey("dbo.Users", t => t.User_id_user)
                .Index(t => t.id_schedule)
                .Index(t => t.User_id_user);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleStudents", "User_id_user", "dbo.Users");
            DropForeignKey("dbo.ScheduleStudents", "id_schedule", "dbo.Schedules");
            DropForeignKey("dbo.Scores", "id_user", "dbo.Users");
            DropForeignKey("dbo.Scores", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "id_user", "dbo.Users");
            DropForeignKey("dbo.Users", "id_role", "dbo.Roles");
            DropForeignKey("dbo.Schedules", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "id_grade", "dbo.Grades");
            DropForeignKey("dbo.Courses", "id_subject", "dbo.Subjects");
            DropIndex("dbo.ScheduleStudents", new[] { "User_id_user" });
            DropIndex("dbo.ScheduleStudents", new[] { "id_schedule" });
            DropIndex("dbo.Scores", new[] { "id_user" });
            DropIndex("dbo.Scores", new[] { "id_subject" });
            DropIndex("dbo.Users", new[] { "id_role" });
            DropIndex("dbo.Schedules", new[] { "id_grade" });
            DropIndex("dbo.Schedules", new[] { "id_user" });
            DropIndex("dbo.Schedules", new[] { "id_subject" });
            DropIndex("dbo.Courses", new[] { "id_subject" });
            DropTable("dbo.ScheduleStudents");
            DropTable("dbo.Scores");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Grades");
            DropTable("dbo.Schedules");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
        }
    }
}
