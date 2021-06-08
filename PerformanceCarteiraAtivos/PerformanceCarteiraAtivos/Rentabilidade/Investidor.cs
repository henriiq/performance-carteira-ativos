using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceCarteiraAtivos.Rentabilidade
{
    public class Investidor
    {
        public Guid Id { get; set; }
        public IEnumerable<Carteira> Carteiras { get; set; }

        public decimal CalcularRentabilidadeInvestimento(DateTime inicio, DateTime fim)
        {
            var c0 = Carteiras.Single(w => w.Data.Date == inicio.Date);
            var c1 = Carteiras.Single(w => w.Data.Date == fim.Date);

            return c1.CalculaPrecoCarteira() - c0.CalculaPrecoCarteira();
        }

        public decimal CalcularRentabilidadeInvestimentoPorAcao(string codigoNegociacao, DateTime inicio, DateTime fim)
        {
            var c0 = Carteiras.Single(w => w.Data.Date == inicio.Date);
            var c1 = Carteiras.Single(w => w.Data.Date == fim.Date);

            var a0 = c0.Acoes.Single(w => w.CodigoNegociacao == codigoNegociacao);
            var a1 = c1.Acoes.Single(w => w.CodigoNegociacao == codigoNegociacao);

            return a1.CalculaPrecoTotal() - a0.CalculaPrecoTotal();
        }
    }
}
