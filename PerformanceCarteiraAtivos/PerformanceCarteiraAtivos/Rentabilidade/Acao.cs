using System;

namespace PerformanceCarteiraAtivos.Rentabilidade
{
    public class Acao
    {
        public string CodigoNegociacao { get; set; }
        public decimal Preco { get; set; }
        public long Quantidade { get; set; }

        public decimal CalculaPrecoTotal() => Quantidade * Preco;

        public Guid CarteiraId { get; set; }
    }
}
