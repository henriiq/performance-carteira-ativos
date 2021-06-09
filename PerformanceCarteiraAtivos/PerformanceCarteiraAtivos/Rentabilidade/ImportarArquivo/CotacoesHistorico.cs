using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PerformanceCarteiraAtivos.Rentabilidade.ImportarArquivo
{
    public static class LayoutArquivoCotacaoHistorico
    {
#pragma warning disable S1104 // Fields should not have public accessibility
        public static IEnumerable<ArquivoCotacao> LayoutHeader = new[]
        {
            new ArquivoCotacao {NomeCampo = "TIPO DE REGISTRO", Tipo = "N", Tamanho = 2, PosicaoInicial = 1, PosicaoFinal = 2},
            new ArquivoCotacao {NomeCampo = "NOME DO ARQUIVO", Tipo = "X", Tamanho = 13, PosicaoInicial = 3, PosicaoFinal = 15},
            new ArquivoCotacao {NomeCampo = "CÓDIGO DA ORIGEM", Tipo = "X", Tamanho = 8, PosicaoInicial = 16, PosicaoFinal = 23},
            new ArquivoCotacao {NomeCampo = "DATA DA GERAÇÃO DO ARQUIVO", Tipo = "N", Tamanho = 8, PosicaoInicial =24, PosicaoFinal = 31},
            new ArquivoCotacao {NomeCampo = "RESERVA", Tipo = "X", Tamanho = 214, PosicaoInicial =32, PosicaoFinal = 245},
        };
#pragma warning restore S1104 // Fields should not have public accessibility

#pragma warning disable S1104 // Fields should not have public accessibility
        public static IEnumerable<ArquivoCotacao> LayoutCorpo = new[]
        {
            new ArquivoCotacao {NomeCampo = "TIPREG - TIPO DE REGISTRO", Tipo = "N", Tamanho = 2, PosicaoInicial = 1, PosicaoFinal = 2},
            new ArquivoCotacao {NomeCampo = "DATA DO PREGÃO", Tipo = "N", Tamanho = 8, PosicaoInicial = 3, PosicaoFinal = 10},
            new ArquivoCotacao {NomeCampo = "CODBDI - CÓDIGO BDI", Tipo = "X", Tamanho = 2, PosicaoInicial = 11, PosicaoFinal = 12},
            new ArquivoCotacao {NomeCampo = "CODNEG - CÓDIGO DE NEGOCIAÇÃO DO PAPEL", Tipo = "X", Tamanho = 12, PosicaoInicial =13, PosicaoFinal = 24},
            new ArquivoCotacao {NomeCampo = "TPMERC - TIPO DE MERCADO", Tipo = "N", Tamanho = 3, PosicaoInicial =25, PosicaoFinal = 27},
            new ArquivoCotacao {NomeCampo = "NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL", Tipo = "X", Tamanho = 12, PosicaoInicial =28, PosicaoFinal = 39},
            new ArquivoCotacao {NomeCampo = "ESPECI - ESPECIFICAÇÃO DO PAPEL", Tipo = "X", Tamanho = 10, PosicaoInicial = 40, PosicaoFinal = 49},
            new ArquivoCotacao {NomeCampo = "PRAZOT - PRAZO EM DIAS DO MERCADO A TERMO", Tipo = "X", Tamanho = 3, PosicaoInicial = 50, PosicaoFinal = 52},
            new ArquivoCotacao {NomeCampo = "MODREF - MOEDA DE REFERÊNCIA", Tipo = "X", Tamanho = 4, PosicaoInicial = 53, PosicaoFinal = 56},
            new ArquivoCotacao {NomeCampo = "PREABE - PREÇO DE ABERTURA DO PAPELMERCADO NO PREGÃO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 57, PosicaoFinal = 69},
            new ArquivoCotacao {NomeCampo = "PREMAX - PREÇO MÁXIMO DO PAPELMERCADO NO PREGÃO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 70, PosicaoFinal = 82},
            new ArquivoCotacao {NomeCampo = "PREMIN - PREÇO MÍNIMO DO PAPEL MERCADO NO PREGÃO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 83, PosicaoFinal = 95},
            new ArquivoCotacao {NomeCampo = "PREMED - PREÇO MÉDIO DO PAPEL MERCADO NO PREGÃO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 96, PosicaoFinal = 108},
            new ArquivoCotacao {NomeCampo = "PREULT - PREÇO DO ÚLTIMO NEGÓCIO DO PAPEL-MERCADO NO PREGÃO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 109, PosicaoFinal = 121},
            new ArquivoCotacao {NomeCampo = "PREOFC - PREÇO DA MELHOR OFERTA DE COMPRA DO PAPELMERCADO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 122, PosicaoFinal = 134},
            new ArquivoCotacao {NomeCampo = "PREOFV - PREÇO DA MELHOR OFERTA DE VENDA DO PAPELMERCADO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 135, PosicaoFinal = 147},
            new ArquivoCotacao {NomeCampo = "TOTNEG - NEG. -NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL- MERCADO NO PREGÃO", Tipo = "N", Tamanho = 5, PosicaoInicial = 148, PosicaoFinal = 152},
            new ArquivoCotacao {NomeCampo = "QUATOT - QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPEL- MERCADO", Tipo = "N", Tamanho = 18, PosicaoInicial = 153, PosicaoFinal = 170},
            new ArquivoCotacao {NomeCampo = "VOLTOT - VOLUME TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPEL- MERCADO", Tipo = "V99", Tamanho = 16, PosicaoInicial = 171, PosicaoFinal = 188},
            new ArquivoCotacao {NomeCampo = "PREEXE - PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DO CONTRATO PARA O MERCADO DE TERMO SECUNDÁRIO", Tipo = "V99", Tamanho = 11, PosicaoInicial = 189, PosicaoFinal = 201},
            new ArquivoCotacao {NomeCampo = "NDOPC - INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES OU TERMO SECUNDÁRIO", Tipo = "N", Tamanho = 1, PosicaoInicial = 202, PosicaoFinal = 202},
            new ArquivoCotacao {NomeCampo = "DATVEN - DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES OU TERMO SECUNDÁRIO", Tipo = "N", Tamanho = 8, PosicaoInicial = 203, PosicaoFinal = 210},
            new ArquivoCotacao {NomeCampo = "FATCOT - FATOR DE COTAÇÃO DO PAPEL", Tipo = "N", Tamanho = 7, PosicaoInicial = 211, PosicaoFinal = 217},
            new ArquivoCotacao {NomeCampo = "PTOEXE - PREÇO DE EXERCÍCIO EM PONTOS PARA OPÇÕES REFERENCIADAS EM DÓLAR OU VALOR DE CONTRATO EM PONTOS PARA TERMO SECUNDÁRIO", Tipo = "V06", Tamanho = 7, PosicaoInicial = 218, PosicaoFinal = 230},
            new ArquivoCotacao {NomeCampo = "CODISI - CÓDIGO DO PAPEL NO SISTEMA ISIN OU CÓDIGO INTERNO DO PAPEL", Tipo = "X", Tamanho = 12, PosicaoInicial = 231, PosicaoFinal = 242},
            new ArquivoCotacao {NomeCampo = "DISMES - NÚMERO DE DISTRIBUIÇÃO DO PAPEL", Tipo = "9", Tamanho = 3, PosicaoInicial = 243, PosicaoFinal = 245},
        };
#pragma warning restore S1104 // Fields should not have public accessibility
    }

    public class ArquivoCotacao
    {
        public string NomeCampo { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }
        public int PosicaoInicial { get; set; }
        public int PosicaoFinal { get; set; }
    }

    public class Importador
    {
        public void Importar(string path)
        {
            var linhas = File.ReadLines(path).ToArray();

            var header = linhas[0];
            var dicHeader = new Dictionary<string, string>();

            foreach (var h in LayoutArquivoCotacaoHistorico.LayoutHeader)
                dicHeader.Add(h.NomeCampo, header.Substring(h.PosicaoInicial - 1, h.Tamanho));

            var corpo = linhas.Skip(1);
            var dicBodys = new List<Dictionary<string, string>>();

            foreach (var c in corpo)
            {
                var dicBody = new Dictionary<string, string>();

                foreach (var h in LayoutArquivoCotacaoHistorico.LayoutCorpo)
                    dicBody.Add(h.NomeCampo, c.Substring(h.PosicaoInicial - 1, h.PosicaoFinal - h.PosicaoInicial + 1));

                dicBodys.Add(dicBody);
            }
        }
    }
}
