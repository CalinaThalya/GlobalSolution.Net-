using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HydrioMind.Usuario.Data.Migrations
{
    public partial class AddUsuariosToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Nome", "Razao_Social", "Email", "CNPJ" },
                values: new object[,]
                {
                    { "João Silva", "João Silva Ltda", "joao.silva@empresa.com", "12345678000123" },
                    { "Maria Oliveira", "Maria Oliveira Comércio", "maria.oliveira@empresa.com", "98765432000198" },
                    { "Pedro Santos", "Pedro Santos ME", "pedro.santos@empresa.com", "19283746000123" },
                    { "Ana Costa", "Ana Costa Indústria", "ana.costa@empresa.com", "45678901234567" },
                    { "Lucas Pereira", "Lucas Pereira Comércio", "lucas.pereira@empresa.com", "11223344556677" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 } // IDs dos registros inseridos
            );
        }
    }
}
