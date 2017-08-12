namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Publicacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Publicado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Data", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Data");
            DropColumn("dbo.Posts", "Publicado");
        }
    }
}
