using System;

namespace PerformanceCarteiraAtivos.Rentabilidade
{
    public class Acao
    {
        public Guid CarteiraId { get; set; }
        public string CodigoNegociacao { get; set; }
        public decimal Preco { get; set; }
        public long Quantidade { get; set; }

        public decimal CalculaPrecoTotal() => Quantidade * Preco;
    }
}
