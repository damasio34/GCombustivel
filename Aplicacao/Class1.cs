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

            var veiculos = ObterVeiculos(linhas);
            var rotas = ObterRotas(linhas, veiculos, veiculos.Count() + 2);

            return rotas;
        }

        private List<Rota> ObterRotas(string[] linhas, IEnumerable<Veiculo> veiculos, int linhaAtual, int quantidadeDeDias = 0, 
            int diatual = 0, int dia = 0, List<Rota> rotas = null)
        {
            if (linhaAtual >= linhas.Length - 1 || linhas[linhaAtual] == "") return rotas;

            if (rotas == null) rotas = new List<Rota>();
            if (quantidadeDeDias == 0) quantidadeDeDias = int.Parse(linhas[linhaAtual++]);
            if (diatual == 0 || diatual > quantidadeDeDias)
            {
                diatual = 1;
                dia++;
            }

            var codigoDoVeiculo = int.Parse(linhas[linhaAtual++]);
            var quantidadeDeTrechos = int.Parse(linhas[linhaAtual++]);

            var veiculo = veiculos.Single(p => p.Codigo.Equals(codigoDoVeiculo));
            var trechos = ObterTrechos(linhas, linhaAtual, veiculo);

            var rota = rotas.SingleOrDefault(p => p.Dia.Equals(dia));
            if (rota != null) rota.AdicionarVeiculo(veiculo);
            else rotas.Add(new Rota(dia, veiculo));

            return ObterRotas(linhas, veiculos, linhaAtual + quantidadeDeTrechos + 1, quantidadeDeDias, diatual + 1, dia, rotas);
        }
        private List<Trecho> ObterTrechos(string[] linhas, int linhaAtual, Veiculo veiculo, List<Trecho> trechos = null)
        {
            if (linhas[linhaAtual] == "") return trechos;
            var posicaoDoEspaco = linhas[linhaAtual].IndexOf(" ");
            var codigoDaCidade = linhas[linhaAtual].Substring(0, posicaoDoEspaco);
            var quilometragem = int.Parse(linhas[linhaAtual].Substring(posicaoDoEspaco));

            if (trechos == null) trechos = new List<Trecho>();
            trechos.Add(new Trecho(codigoDaCidade, quilometragem, veiculo));

            return ObterTrechos(linhas, linhaAtual + 1, veiculo, trechos);
        }

        private IEnumerable<Veiculo> ObterVeiculos(string[] linhas)
        {
            var quantidadeDeVeiculos = int.Parse(linhas[0]);
            for (int i = 1; i < quantidadeDeVeiculos + 1; i++)
            {
                var posicaoDoEspaco = linhas[i].IndexOf(" ");
                var codigo = int.Parse(linhas[i].Substring(0, posicaoDoEspaco));
                var consumoMedio = int.Parse(linhas[i].Substring(posicaoDoEspaco));

                yield return new Veiculo(codigo, consumoMedio);
            }
        }
    }
}
