namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOfResource = c.Int(nullable: false),
                        Link = c.String(),
                        CourseId = c.Int(nullable: false),
                        Courses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Courses_Id)
                .Index(t => t.Courses_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(maxLength: 10),
                        RegistrationDate = c.DateTime(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        HomeworkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homeworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ContentType = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        Students_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Students_Id, t.Courses_Id })
                .ForeignKey("dbo.Students", t => t.Students_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id, cascadeDelete: true)
                .Index(t => t.Students_Id)
                .Index(t => t.Courses_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homeworks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Homeworks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.Resources", "Courses_Id", "dbo.Courses");
            DropIndex("dbo.StudentsCourses", new[] { "Courses_Id" });
            DropIndex("dbo.StudentsCourses", new[] { "Students_Id" });
            DropIndex("dbo.Homeworks", new[] { "CourseId" });
            DropIndex("dbo.Homeworks", new[] { "StudentId" });
            DropIndex("dbo.Resources", new[] { "Courses_Id" });
            DropTable("dbo.StudentsCourses");
            DropTable("dbo.Homeworks");
            DropTable("dbo.Students");
            DropTable("dbo.Resources");
            DropTable("dbo.Courses");
        }
    }
}
