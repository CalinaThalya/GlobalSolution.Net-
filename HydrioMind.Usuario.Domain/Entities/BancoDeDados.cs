using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HydrioMind.Usuario.Domain.Entities;



public class BancoDeDadosMongo
{
    private readonly IMongoDatabase mongoDatabase;

    public BancoDeDadosMongo(string connectionString)
    {
        var client = new MongoClient(connectionString);
        mongoDatabase = client.GetDatabase("nomeDoBanco");  // Substitua pelo nome do seu banco
    }

    public async Task<IEnumerable<DadosRecomendacao>> BuscarDadosRecomendacaoAsync()
    {
        var collection = mongoDatabase.GetCollection<BsonDocument>("Usuarios");

        // Pipeline de agregação para unir as coleções aninhadas (como IA e Análises de Desperdício)
        var pipeline = new[]
        {
            new BsonDocument("$unwind", "$IA"),  // Desenrola o array de IA
            new BsonDocument("$unwind", "$IA.Analise_Desperdicio"),  // Desenrola o array de Análises
            new BsonDocument("$project", new BsonDocument
            {
                { "Razao_Social", 1 },
                { "Email", 1 },
                { "CNPJ", 1 },
                { "IA.Nome_IA", 1 },
                { "IA.Descricao_IA", 1 },
                { "IA.Consumo_Atual", 1 },
                { "IA.Desperdicio_Calculado", 1 },
                { "IA.Recomendacao", 1 },
                { "IA.Implementada", 1 },
                { "IA.Analise_Desperdicio.Data_Analise", 1 },
                { "IA.Analise_Desperdicio.Desperdicio_Calculado", 1 }
            })
        };

        var recomendacoes = await collection.Aggregate<BsonDocument>(pipeline).ToListAsync();

        var dadosRecomendacao = new List<DadosRecomendacao>();

        // Mapeando os dados de BsonDocument para DadosRecomendacao
        foreach (var item in recomendacoes)
        {
            dadosRecomendacao.Add(new DadosRecomendacao
            {
                Razao_Social = item["Razao_Social"].AsString,
                Email = item["Email"].AsString,
                CNPJ = item["CNPJ"].AsString,
                Nome_IA = item["IA"]["Nome_IA"].AsString,
                Descricao_IA = item["IA"]["Descricao_IA"].AsString,
                Consumo_Atual = item["IA"]["Consumo_Atual"].AsString,
                Desperdicio_Calculado = item["IA"]["Desperdicio_Calculado"].AsString,
                Recomendacao = item["IA"]["Recomendacao"].AsString,
                Implementada = item["IA"]["Implementada"].AsBoolean,
                Data_Analise = item["IA"]["Analise_Desperdicio"]["Data_Analise"].ToUniversalTime()
            });
        }

        return dadosRecomendacao;
    }
}
