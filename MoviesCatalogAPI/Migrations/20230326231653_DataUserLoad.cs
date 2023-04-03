using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

#nullable disable

namespace MoviesCatalogAPI.Migrations
{
    public partial class DataUserLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies(MovieName,MovieReleaseyear,MovieSynopsis,MovieCategory,MovieCreatedDate) Values('TED','2001','SINOPSIS 1','COMEDY',convert(datetime,'" + DateTime.Now +"',105))");
            migrationBuilder.Sql("INSERT INTO Movies(MovieName,MovieReleaseyear,MovieSynopsis,MovieCategory,MovieCreatedDate) Values('TERMINATOR','1983','SINOPSIS 2','ACTION',convert(datetime,'" + DateTime.Now + "',105))");
            migrationBuilder.Sql("INSERT INTO Movies(MovieName,MovieReleaseyear,MovieSynopsis,MovieCategory,MovieCreatedDate) Values('UNDERWORLD','2005','SINOPSIS 3','TERROR',convert(datetime,'" + DateTime.Now + "',105))");

            migrationBuilder.Sql("INSERT INTO Users(UserName,UserEmail,UserPassword,UserRol) Values('JOSE','jose@gmail.com','jose12','ADMIN')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
