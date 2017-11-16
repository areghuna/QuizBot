namespace QuestionBankApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionTexttoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "OptionText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "OptionText", c => c.Int(nullable: false));
        }
    }
}
