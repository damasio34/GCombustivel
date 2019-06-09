using Damasio34.GCombustivel.Dominio;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aplicacao
{
    public class RotaService
    {
        public IEnumerable<Rota> LerArquivo()
        {
            var queue = this.LerArquivoDeEntrada("entrada_func_a.txt");
            var veiculos = ObterVeiculos(queue);
            var rotas = ObterRotas(queue, veiculos);

            return rotas;
        }

        public Queue<string> LerArquivoDeEntrada(string nomeDoArquivo)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var linhas = File.ReadAllLines($"{path}/Inputs/{nomeDoArquivo}");
            var queue = new Queue<string>(linhas);

            return queue;
        }

        public List<Rota> ObterRotas(Queue<string> linhas, IEnumerable<Veiculo> veiculos)
            => this.ObterRotas(linhas, veiculos, 0, new List<Rota>());
        private List<Rota> ObterRotas(Queue<string> linhas, IEnumerable<Veiculo> veiculos, int numeroDeDias, List<Rota> rotas)
        {
            int dia = numeroDeDias + 1;

            if (!linhas.Any()) return rotas;
            if (numeroDeDias == 0) numeroDeDias = int.Parse(linhas.Dequeue());
            
            //var veiculo = veiculos.Single(p => p.Codigo.Equals(codigoDoVeiculo));
            
            var rota = new Rota(dia);

            foreach (var veiculo in veiculos)
            {
                var codigoDoVeiculo = int.Parse(linhas.Dequeue());
                var quantidadeDeTrechos = int.Parse(linhas.Dequeue()); // Não foi necessário utulizar
                var roteiro = new Roteiro(veiculo);
                var trechos = ObterTrechos(linhas, roteiro);                
                rota.Roteiros.Add(roteiro);

                linhas.Dequeue();
            }

            rotas.Add(rota);

            return ObterRotas(linhas, veiculos, dia, rotas);
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
