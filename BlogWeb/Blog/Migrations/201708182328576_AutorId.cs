namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutorId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Autor_Id", newName: "AutorId");
            RenameIndex(table: "dbo.Posts", name: "IX_Autor_Id", newName: "IX_AutorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_AutorId", newName: "IX_Autor_Id");
            RenameColumn(table: "dbo.Posts", name: "AutorId", newName: "Autor_Id");
        }
    }
}
