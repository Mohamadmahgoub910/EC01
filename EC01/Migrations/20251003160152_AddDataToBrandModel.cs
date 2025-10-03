using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC01.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToBrandModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Brands (Name, Description, Status) VALUES ('BrandA', 'Description for BrandA', 1)");
            migrationBuilder.Sql("INSERT INTO Brands (Name, Description, Status) VALUES ('BrandB', 'Description for BrandB', 1)");
            migrationBuilder.Sql("insert into Brands (Name, Description, Status) values ('Apple', null, 0);" +
                "insert into Brands (Name, Description, Status) values ('Samsoung', null, 0);" +
                "insert into Brands (Name, Description, Status) values ('OPPO', null, 1);" +
                "insert into Brands (Name, Description, Status) values ('Huawi', null, 1);" +
                "insert into Brands (Name, Description, Status) values ('Gucci', null, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Brands");
        }
    }
}
