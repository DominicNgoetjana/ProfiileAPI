namespace ProfileAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MobileNumber = c.String(maxLength: 15),
                        EmailAddress = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Surname = c.String(maxLength: 100),
                        IDNumber = c.String(maxLength: 13),
                        PassportNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactDetails");
        }
    }
}
