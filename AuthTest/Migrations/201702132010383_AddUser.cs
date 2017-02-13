namespace AuthTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BCADUSER",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        UserLogin = c.String(),
                        UserPassword = c.String(),
                        UserName = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BCADUSER");
        }
    }
}
