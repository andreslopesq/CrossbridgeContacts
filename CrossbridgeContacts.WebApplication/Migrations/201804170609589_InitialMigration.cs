namespace CrossbridgeContacts.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        IdContact = c.Int(nullable: false, identity: true),
                        Company = c.String(maxLength: 150),
                        FullName = c.String(maxLength: 200),
                        FirstName = c.String(maxLength: 50),
                        Middle = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Department = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdContact);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
