namespace RegisterSubjectAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ScheduleStudents", new[] { "User_id_user" });
            RenameColumn(table: "dbo.ScheduleStudents", name: "User_id_user", newName: "id_user");
            DropPrimaryKey("dbo.ScheduleStudents");
            AlterColumn("dbo.ScheduleStudents", "id_user", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ScheduleStudents", new[] { "id_user", "id_schedule" });
            CreateIndex("dbo.ScheduleStudents", "id_user");
            DropColumn("dbo.ScheduleStudents", "id_student");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleStudents", "id_student", c => c.Int(nullable: false));
            DropIndex("dbo.ScheduleStudents", new[] { "id_user" });
            DropPrimaryKey("dbo.ScheduleStudents");
            AlterColumn("dbo.ScheduleStudents", "id_user", c => c.Int());
            AddPrimaryKey("dbo.ScheduleStudents", new[] { "id_student", "id_schedule" });
            RenameColumn(table: "dbo.ScheduleStudents", name: "id_user", newName: "User_id_user");
            CreateIndex("dbo.ScheduleStudents", "User_id_user");
        }
    }
}
