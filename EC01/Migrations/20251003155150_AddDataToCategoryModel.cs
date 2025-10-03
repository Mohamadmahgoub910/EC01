using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC01.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name, Description, Status) VALUES ('Electronics', 'Electronic devices and gadgets', 1)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, Description, Status) VALUES ('Clothing', 'Apparel and accessories', 1)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, Description, Status) VALUES ('Home & Kitchen', 'Household items and kitchenware', 1)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, Description, Status) VALUES ('Books', 'Fiction and non-fiction books', 1)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, Description, Status) VALUES ('Sports & Outdoors', 'Sporting goods and outdoor equipment', 1)");
            migrationBuilder.Sql("insert into Categories (Name, Description, Status) values ('Mobiles', 'Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue.', 1);insert into Categories (Name, Description, Status) values ('Computers', 'Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.', 0);insert into Categories (Name, Description, Status) values ('Camera', 'Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.', 1);insert into Categories (Name, Description, Status) values ('Accessories', 'Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue.', 1);insert into Categories (Name, Description, Status) values ('Mobiles', 'Nulla justo.', 1);");




        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Categories");
        }
    }
}
