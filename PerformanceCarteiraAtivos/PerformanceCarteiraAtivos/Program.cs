﻿using PerformanceCarteiraAtivos.Rentabilidade;
using PerformanceCarteiraAtivos.Rentabilidade.Infra.Repositorios;
using System;

namespace PerformanceCarteiraAtivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Investidor investidor;
            var id = Guid.NewGuid();

            using (var repo = new BaseRepository<Investidor>())
            {
                repo.Adicionar(new Investidor
                {
                    Id = id,
                    Carteiras = new[]
                    {
                        new Carteira
                        {
                            Data = DateTime.Now.AddDays(-1),
                            Acoes = new[]
                            {
                                new Acao {CodigoNegociacao = "BPAC11", Preco = 121.25m, Quantidade = 38},
                                new Acao {CodigoNegociacao = "BRKM5", Preco = 57.91m, Quantidade = 100},
                            }
                        },
                        new Carteira
                        {
                            Data = DateTime.Now,
                            Acoes = new[]
                            {
                                new Acao {CodigoNegociacao = "BPAC11", Preco = 122.25m, Quantidade = 38},
                                new Acao {CodigoNegociacao = "BRKM5", Preco = 58.91m, Quantidade = 100},
                            }
                        }
                    }
                });

                repo.Salvar();

                investidor = repo.Obtem(id);
            }

            Console.WriteLine($"BPAC11:---------{investidor.CalcularRentabilidadeInvestimentoPorAcao("BPAC11", DateTime.Now.AddDays(-1), DateTime.Now)}");
            Console.WriteLine($"BRKM5:----------{investidor.CalcularRentabilidadeInvestimentoPorAcao("BRKM5", DateTime.Now.AddDays(-1), DateTime.Now)}");
            Console.WriteLine($"RENTABILIDADE:--{investidor.CalcularRentabilidadeInvestimento(DateTime.Now.AddDays(-1), DateTime.Now)}");
            Console.ReadKey();
        }
    }
}