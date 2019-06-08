using Aplicacao;
using System;

namespace GCombustivel
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new Class1();
            var rotas = class1.LerArquivo();

            foreach (var rota in rotas)
            {
                Console.WriteLine("+-------------+");
                Console.WriteLine($"| ROTA DIA {rota.Dia} | ");
                Console.WriteLine("+-------------+");

                foreach (var veiculo in rota.Veiculos)
                {
                    //CARRO A: 35 km CIDADE A, 80 km CIDADE B, 22 km VOLTAR
                    var mensagem = $"CARRO {veiculo.Codigo}: ";
                    foreach (var trecho in veiculo.Trechos)
                    {
                        if (trecho.Codigo.Equals("0")) mensagem = mensagem + $"{trecho.Quilometragem} km VOLTAR ";
                        else mensagem = mensagem + $"{trecho.Quilometragem} km CIDADE {trecho.Codigo}, "; 
                    }
                    Console.WriteLine(mensagem);
                }
            }

            Console.ReadKey();
        }
    }
}
