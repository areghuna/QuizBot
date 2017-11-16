namespace QuestionBankApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionPapers",
                c => new
                    {
                        QuestionPaperId = c.Int(nullable: false, identity: true),
                        QuestionPaperName = c.String(),
                        QuestionPaperDescription = c.String(),
                    })
                .PrimaryKey(t => t.QuestionPaperId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        Explanation = c.String(),
                        QuestionPaper_QuestionPaperId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionPapers", t => t.QuestionPaper_QuestionPaperId)
                .Index(t => t.QuestionPaper_QuestionPaperId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        OptionText = c.Int(nullable: false),
                        isAnswer = c.Boolean(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionPaper_QuestionPaperId", "dbo.QuestionPapers");
            DropForeignKey("dbo.Options", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Options", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionPaper_QuestionPaperId" });
            DropTable("dbo.Options");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionPapers");
        }
    }
}
