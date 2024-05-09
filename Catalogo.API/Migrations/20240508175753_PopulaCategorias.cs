using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO public.\"Categories\" (\"Name\") VALUES('Bebidas');");
            mb.Sql("INSERT INTO public.\"Categories\" (\"Name\") VALUES('Frutas');");
            mb.Sql("INSERT INTO public.\"Categories\" (\"Name\") VALUES('Legumes');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from \"Categories\" ");
        }
    }
}
