using Damasio34.GCombustivel.Dominio;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aplicacao
{
    public class Class1
    {
        public IEnumerable<Rota> LerArquivo()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var linhas = File.ReadAllLines($"{path}/Inputs/entrada_func_a.txt");
            var queue = new Queue<string>(linhas);

            var veiculos = ObterVeiculos(queue).ToList();
            var rotas = ObterRotas(queue, veiculos);

            return rotas;
        }

        private List<Rota> ObterRotas(Queue<string> linhas, IEnumerable<Veiculo> veiculos, int numeroDeDias = 0, List<Rota> rotas = null)
        {
            if (!linhas.Any()) return rotas;
            if (rotas == null) rotas = new List<Rota>();
            if (numeroDeDias == 0) numeroDeDias = int.Parse(linhas.Dequeue());

            var codigoDoVeiculo = int.Parse(linhas.Dequeue());
            var quantidadeDeTrechos = int.Parse(linhas.Dequeue()); // Não precisei utulizar

            var veiculo = veiculos.Single(p => p.Codigo.Equals(codigoDoVeiculo));

            //Considerando que não pode haver mais de uma rota para um mesmo veículo no mesmo dia
            var quantidadeDeRotaParaOVeiculo = rotas.Count(p => p.Veiculos.Any(x => x.Codigo.Equals(codigoDoVeiculo)));
            var dia = quantidadeDeRotaParaOVeiculo == 0 ? 1 : quantidadeDeRotaParaOVeiculo + 1;

            var rota = rotas.SingleOrDefault(p => p.Dia.Equals(dia));
            if (rota == null)
            {
                rota = new Rota(dia, veiculo);
                rotas.Add(rota);
            }
            else rota.AdicionarVeiculo(veiculo);

            ObterTrechos(linhas, rota, veiculo);

            linhas.Dequeue();

            return ObterRotas(linhas, veiculos, numeroDeDias, rotas);
        }
        private List<Trecho> ObterTrechos(Queue<string> linhas, Rota rota, Veiculo veiculo, List<Trecho> trechos = null)
        {
            if (linhas.Peek() == "") return trechos;
            var linha = linhas.Dequeue().Split(' ');
            var codigoDaCidade = linha[0];
            var quilometragem = int.Parse(linha[1]);

            if (trechos == null) trechos = new List<Trecho>();
            trechos.Add(new Trecho(rota, veiculo, codigoDaCidade, quilometragem));

            return ObterTrechos(linhas, rota, veiculo, trechos);
        }
        private IEnumerable<Veiculo> ObterVeiculos(Queue<string> linhas)
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
