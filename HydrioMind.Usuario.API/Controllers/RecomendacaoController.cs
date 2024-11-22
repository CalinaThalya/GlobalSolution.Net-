using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class DadosRecomendacao
{
    public string Razao_Social { get; set; }
    public string Email { get; set; }
    public string CNPJ { get; set; }
    public string Nome_IA { get; set; }
    public string Descricao_IA { get; set; }
    public string Consumo_Atual { get; set; }
    public string Desperdicio_Calculado { get; set; }
    public string Recomendacao { get; set; }
    public bool Implementada { get; set; }
}

public class BancoDeDados
{
    private string connectionString = "SuaStringDeConexaoAqui";

    public IEnumerable<DadosRecomendacao> BuscarDadosRecomendacao()
    {
        using (IDbConnection dbConnection = new SqlConnection(connectionString))
        {
            dbConnection.Open();
            var query = @"
                SELECT 
                    u.Razao_Social, 
                    u.Email, 
                    u.cnpj, 
                    i.Nome_IA, 
                    i.Descricao AS Descricao_IA, 
                    i.Consumo_Atual, 
                    ad.Desperdicio_Calculado, 
                    r.Descricao AS Recomendacao, 
                    r.Implementada
                FROM 
                    Usuario u
                    INNER JOIN IA i ON i.Usuario_ID_Usuario = u.ID_Usuario
                    INNER JOIN Analise_Desperdicio ad ON ad.IA_ID_IA = i.ID_IA
                    INNER JOIN Recomendacao r ON r.Analise_Desperdicio_ID_Analise = ad.ID_Analise
            ";
            return dbConnection.Query<DadosRecomendacao>(query);
        }
    }
}
