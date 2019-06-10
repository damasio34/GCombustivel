using Damasio34.GCombustivel.Aplicacao.Services;
using System;

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

            Console.WriteLine("+ --------------------------------------------------+");
            Console.WriteLine("Pressione qualquer tecla para gerar arquivo de saída.");
            Console.WriteLine("+ --------------------------------------------------+");
            Console.ReadKey();

            rotaService.EscreverRelatorio(arquivoService, "saida_func_a.txt", rotas);            

            Console.WriteLine("+ ------------------------+");
            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine("+ ------------------------+");
            Console.WriteLine("+ -----------------------------------------------------------+");
            Console.WriteLine("Pressione qualquer tecla para exibir relatório de combustivel.");
            Console.WriteLine("+ -----------------------------------------------------------+");
            Console.ReadKey();

            var rotasECombustivel = rotaService.LerRelatorioComCombustivel(arquivoService, "entrada_func_b.txt");
            var restante = rotasECombustivel.Item2;
            foreach (var rota in rotasECombustivel.Item1)
            {
                restante -= rota.ConsumoMedio;
                if (restante > 0) Console.WriteLine($"ROTA DIA {rota.Dia}: COMBUSTIVEL RESTANTE: {restante} litros");
                else Console.WriteLine($"ROTA DIA {rota.Dia}: SEM COMBUSTÌVEL SUFICIENTE");
            }

            Console.WriteLine("+ --------------------------------------------------+");
            Console.WriteLine("Pressione qualquer tecla para exibir relatório de combustivel.");
            Console.WriteLine("+ --------------------------------------------------+");
            Console.ReadKey();

            rotaService.EscreverRelatorioDeCombustivel(arquivoService, "saida_func_b.txt",
                rotasECombustivel.Item1, rotasECombustivel.Item2);

            Console.WriteLine("+ ------------------------+");
            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine("+ ------------------------+");
            Console.ReadKey();
        }
    }
}
