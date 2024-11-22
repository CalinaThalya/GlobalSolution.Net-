using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HydrioMind.Usuario.Domain.Entities;
using MongoDB.Driver;


namespace HydrioMind.Usuario.Domain.Entities

{
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
        public DateTime Data_Analise { get; set; }
    }
}