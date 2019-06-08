using Damasio34.GCombustivel.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aplicacao
{
    public class Class1
    {
        public void LerArquivo()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Inputs");
            var linhas = File.ReadAllLines($"{path}/entrada_func_a.txt");
            
            var veiculos = ObterVeiculos(linhas);
            var rotas = ObterRotas(linhas, veiculos);
        }

        private IEnumerable<Rota> ObterRotas(string[] linhas, IEnumerable<Veiculo> veiculos)
        {
            var quantidadeDeDias = int.Parse(linhas[+3]);
            for (int i = veiculos.Count() + 2; i < quantidadeDeDias; i++)
            {
                var dia = 0;                
                var codigoDoVeiculo = int.Parse(linhas[i]);
                var numeroDeRotas = int.Parse(linhas[i + 1]);

                var veiculo = veiculos.Single(p => p.Codigo.Equals(codigoDoVeiculo));
                var trechos = ObterTrechos(linhas, i, numeroDeRotas);

                yield return new Rota(dia++, veiculo, trechos.ToArray());
            }
        }
        private IEnumerable<Trecho> ObterTrechos(string[] linhas, int i, int numeroDeRotas)
        {
            for (int j = i; j < i + numeroDeRotas; j++)
            {
                var posicaoDoEspaco = linhas[j].IndexOf(" ");
                var codigoDaCidade = linhas[j].Substring(0, posicaoDoEspaco);
                var quilometragem = int.Parse(linhas[j].Substring(posicaoDoEspaco));

                yield return new Trecho(codigoDaCidade, quilometragem);
            }
        }   
        private IEnumerable<Veiculo> ObterVeiculos(string[] linhas)
        {
            var quantidadeDeVeiculos = int.Parse(linhas[0]);
            for (int i = 1; i < quantidadeDeVeiculos; i++)
            {
                var posicaoDoEspaco = linhas[i].IndexOf(" ");
                var codigo = int.Parse(linhas[i].Substring(0, posicaoDoEspaco));
                var consumoMedio = int.Parse(linhas[i].Substring(posicaoDoEspaco));

                yield return new Veiculo(codigo, consumoMedio);
            }
        }
    }
}
