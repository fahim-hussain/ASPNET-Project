namespace S2021A6FH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artistalbumrichtextedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Summary", c => c.String());
            AddColumn("dbo.Artists", "Biography", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Biography");
            DropColumn("dbo.Albums", "Summary");
        }
    }
}
