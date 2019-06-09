using Aplicacao;
using System;
using System.Linq;

namespace GCombustivel
{
    class Program
    {
        static void Main(string[] args)
        {
            var arquivoService = new ArquivoService();
            var rotaService = new RotaService();
            var rotas = rotaService.LerRelatorio(arquivoService, "entrada_func_a.txt");

            foreach (var rota in rotas)
            {
                Console.WriteLine("+-------------+");
                Console.WriteLine($"| ROTA DIA {rota.Dia} | ");
                Console.WriteLine("+-------------+");

                foreach (var roteiro in rota.Roteiros)
                {
                    //CARRO A: 35 km CIDADE A, 80 km CIDADE B, 22 km VOLTAR
                    var mensagem = $"CARRO {roteiro.Veiculo.Codigo}: ";
                    foreach (var trecho in roteiro.Trechos)
                    {
                        if (trecho.Cidade.Equals("0")) mensagem = mensagem + $"{trecho.Quilometragem} km VOLTAR ";
                        else mensagem = mensagem + $"{trecho.Quilometragem} km CIDADE {trecho.Cidade}, "; 
                    }
                    Console.WriteLine(mensagem);
                    Console.WriteLine("");
                }
            }

            Console.ReadKey();
        }
    }
}
