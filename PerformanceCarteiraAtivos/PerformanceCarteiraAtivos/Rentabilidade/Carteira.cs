using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceCarteiraAtivos.Rentabilidade
{
    public class Carteira
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Acao> Acoes { get; set; }
        public Investidor Investidor { get; set; }

        public decimal CalculaPrecoCarteira() => Acoes.Sum(s => s.CalculaPrecoTotal());
    }
}
