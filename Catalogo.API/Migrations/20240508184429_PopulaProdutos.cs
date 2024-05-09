using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO \"Products\" (\"Price\", \"Supplier\", \"Description\", \"ExpirationDate\", \"CategoryId\", \"Code\", \"Quantity\") " +
                "VALUES(3.80, 'Heinekein', 'Cerveja Heinekein', now(), 2, 'BE1', 1);");
            mb.Sql("INSERT INTO \"Products\" (\"Price\", \"Supplier\", \"Description\", \"ExpirationDate\", \"CategoryId\", \"Code\", \"Quantity\") " +
                "VALUES(4.80, 'Skol', 'Cerveja Skol', now(), 2, 'BE2', 2);");
            
            mb.Sql("INSERT INTO \"Products\" (\"Price\", \"Supplier\", \"Description\", \"ExpirationDate\", \"CategoryId\", \"Code\", \"Quantity\") " +
                "VALUES(3.80, 'Armazen Sobral', 'Melancia', now(), 3, 'FR1', 13);");
            mb.Sql("INSERT INTO \"Products\" (\"Price\", \"Supplier\", \"Description\", \"ExpirationDate\", \"CategoryId\", \"Code\", \"Quantity\") " +
                "VALUES(4.80, 'Frutaria Santo Antonio', 'Jaca', now(), 3, 'FR2', 12);");
            
            mb.Sql("INSERT INTO \"Products\" (\"Price\", \"Supplier\", \"Description\", \"ExpirationDate\", \"CategoryId\", \"Code\", \"Quantity\") " +
                "VALUES(3.80, 'Armazen Sobral', 'Pimentão', now(), 4, 'LE1', 34);");
            mb.Sql("INSERT INTO \"Products\" (\"Price\", \"Supplier\", \"Description\", \"ExpirationDate\", \"CategoryId\", \"Code\", \"Quantity\") " +
                "VALUES(4.80, 'Fazenda Contendas', 'Cenoura', now(), 4, 'LE2', 22);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from \"Products\"");
        }
    }
}
