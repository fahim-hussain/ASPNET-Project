namespace S2021A6FH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class artistMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistMediaItems",
                c => new
                {
                    MediaId = c.Int(nullable: false, identity: true),
                    StringId = c.String(nullable: false),
                    Caption = c.String(nullable: false),
                    Content = c.Binary(),
                    ContentType = c.String(),
                    Timestamp = c.DateTime(nullable: false),
                    Artist_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.MediaId)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ArtistMediaItems", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.ArtistMediaItems", new[] { "Artist_Id" });
            DropTable("dbo.ArtistMediaItems");
        }
    }
}
