using System.Data.Entity.Migrations;

namespace RoadRules.Migrations
{
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                {
                    Id = c.Int(false, true),
                    Content = c.String(),
                    IsCorrect = c.Boolean(false),
                    QuestionId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, true)
                .Index(t => t.QuestionId);

            CreateTable(
                "dbo.Questions",
                c => new
                {
                    Id = c.Int(false, true),
                    Content = c.String(),
                    Points = c.Double(false),
                    TestId = c.Int(false),
                    QuestionTypeId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, true)
                .ForeignKey("dbo.Tests", t => t.TestId, true)
                .Index(t => t.TestId)
                .Index(t => t.QuestionTypeId);

            CreateTable(
                "dbo.QuestionTypes",
                c => new
                {
                    Id = c.Int(false, true),
                    Content = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tests",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Pieces",
                c => new
                {
                    Id = c.Int(false, true),
                    Position = c.Int(false),
                    ImageData = c.Binary(),
                    ImageType = c.String(),
                    PuzzleId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Puzzles", t => t.PuzzleId, true)
                .Index(t => t.PuzzleId);

            CreateTable(
                "dbo.Puzzles",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PuzzleResults",
                c => new
                {
                    Id = c.Int(false, true),
                    ApplicationUserId = c.String(maxLength: 128),
                    PuzzleId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Puzzles", t => t.PuzzleId, true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.PuzzleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(false, 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(false),
                    TwoFactorEnabled = c.Boolean(false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(false),
                    AccessFailedCount = c.Int(false),
                    UserName = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(false, true),
                    UserId = c.String(false, 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(false, 128),
                    ProviderKey = c.String(false, 128),
                    UserId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(false, 128),
                    RoleId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(false, 128),
                    Name = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.TestResults",
                c => new
                {
                    Id = c.Int(false, true),
                    ApplicationUserId = c.String(maxLength: 128),
                    TestId = c.Int(false),
                    Points = c.Double(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Tests", t => t.TestId, true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.TestId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestResults", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PuzzleResults", "PuzzleId", "dbo.Puzzles");
            DropForeignKey("dbo.PuzzleResults", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pieces", "PuzzleId", "dbo.Puzzles");
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.TestResults", new[] {"TestId"});
            DropIndex("dbo.TestResults", new[] {"ApplicationUserId"});
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.AspNetUserClaims", new[] {"UserId"});
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.PuzzleResults", new[] {"PuzzleId"});
            DropIndex("dbo.PuzzleResults", new[] {"ApplicationUserId"});
            DropIndex("dbo.Pieces", new[] {"PuzzleId"});
            DropIndex("dbo.Questions", new[] {"QuestionTypeId"});
            DropIndex("dbo.Questions", new[] {"TestId"});
            DropIndex("dbo.Answers", new[] {"QuestionId"});
            DropTable("dbo.TestResults");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.PuzzleResults");
            DropTable("dbo.Puzzles");
            DropTable("dbo.Pieces");
            DropTable("dbo.Tests");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}