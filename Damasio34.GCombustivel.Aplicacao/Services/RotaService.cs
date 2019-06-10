using Damasio34.GCombustivel.Dominio;
using Damasio34.GCombustivel.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Damasio34.GCombustivel.Aplicacao.Services
{
    public class RotaService : IRotaService
    {
        public IEnumerable<Rota> LerRelatorio(IArquivoService arquivoService, string nomeDoArquivo)
        {
            var queue = arquivoService.LerArquivoDeEntrada(nomeDoArquivo);
            var veiculos = ObterVeiculos(queue).ToList();
            var rotas = ObterRotas(queue, veiculos);

            return rotas;
        }

        public Tuple<IEnumerable<Rota>, double> LerRelatorioComCombustivel(IArquivoService arquivoService, 
            string nomeDoArquivo)
        {
            var queue = arquivoService.LerArquivoDeEntrada(nomeDoArquivo);
            var veiculos = ObterVeiculos(queue).ToList();
            var rotas = ObterRotas(queue, veiculos);
            var combustivel = ObterCombustivelDisponivel(queue);

            return new Tuple<IEnumerable<Rota>, double>(rotas, combustivel);
        }

        public double ObterCombustivelDisponivel(Queue<string> queue)
        {
            if (!queue.Any() || queue.Peek() == "") return 0;
            return int.Parse(queue.Dequeue());
        }
        public IEnumerable<string> EscreverRelatorio(IArquivoService arquivoService, 
            string nomeDoArquivo, IEnumerable<Rota> rotas)
        {
            var linhas = new List<string> { rotas.Count().ToString() };
            foreach (var rota in rotas)
            {
                foreach (var roteiro in rota.Roteiros)
                {
                    var consumoMedio = (Math.Truncate(100 * roteiro.ConsumoMedio) / 100)
                        .ToString("0.00", new CultureInfo("en-US", false));
                    linhas.Add($"{roteiro.Veiculo.Codigo} {consumoMedio}");
                }
                linhas.Add("");
            }

            arquivoService.EscreverArquivoDeSaida(linhas, nomeDoArquivo);
            return linhas;
        }
        public IEnumerable<string> EscreverRelatorioDeCombustivel(IArquivoService arquivoService, string nomeDoArquivo,
            IEnumerable<Rota> rotas, double combustivel)
        {
            var linhas = new List<string>();
            foreach (var rota in rotas)
            {
                combustivel -= rota.ConsumoMedio;
                if (combustivel <= 0) combustivel = 0;
                linhas.Add(combustivel.ToString("0.##", new CultureInfo("en-US", false)));
            }

            linhas.Insert(0, combustivel.ToString("0.##", new CultureInfo("en-US", false)));
            linhas.Insert(1, "");
            linhas.Add("");

            arquivoService.EscreverArquivoDeSaida(linhas, nomeDoArquivo);
            return linhas;
        }

        public List<Rota> ObterRotas(Queue<string> linhas, IEnumerable<Veiculo> veiculos)
        {
            var rotas = new List<Rota>();
            var numeroDeDias = int.Parse(linhas.Dequeue());
            for (int i = 0; i < numeroDeDias; i++)
            {
                var rota = new Rota(i + 1);

                foreach (var veiculo in veiculos)
                {
                    var codigoDoVeiculo = int.Parse(linhas.Dequeue());
                    var quantidadeDeTrechos = int.Parse(linhas.Dequeue());
                    var roteiro = new Roteiro(veiculo);
                    var trechos = ObterTrechos(linhas, roteiro);
                    rota.Roteiros.Add(roteiro);

                    linhas.Dequeue();
                }

                rotas.Add(rota);
            }

            return rotas;
        }

        public List<Trecho> ObterTrechos(Queue<string> linhas, Roteiro roteiro)
            => this.ObterTrechos(linhas, roteiro, new List<Trecho>());
        private List<Trecho> ObterTrechos(Queue<string> linhas, Roteiro roteiro, List<Trecho> trechos)
        {
            if (linhas.Peek() == "") return trechos;
            var linha = linhas.Dequeue().Split(' ');
            var codigoDaCidade = linha[0];
            var quilometragem = int.Parse(linha[1]);

            trechos.Add(new Trecho(roteiro, codigoDaCidade, quilometragem));

            return ObterTrechos(linhas, roteiro, trechos);
        }

        public IEnumerable<Veiculo> ObterVeiculos(Queue<string> linhas)
        {
            var quantidadeDeVeiculos = int.Parse(linhas.Dequeue());
            for (int i = 1; i < quantidadeDeVeiculos + 1; i++)
            {
                var linha = linhas.Dequeue().Split(' ');
                var codigo = int.Parse(linha[0]);
                var consumoMedio = int.Parse(linha[1]);

                yield return new Veiculo(codigo, consumoMedio);
            }

            linhas.Dequeue();
        }
    }
}
