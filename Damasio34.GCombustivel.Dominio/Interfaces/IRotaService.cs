using System;
using System.Collections.Generic;

namespace Damasio34.GCombustivel.Dominio.Interfaces
{
    public interface IRotaService
    {
        IEnumerable<string> EscreverRelatorio(IArquivoService arquivoService, string nomeDoArquivo, IEnumerable<Rota> rotas);
        IEnumerable<string> EscreverRelatorioDeCombustivel(IArquivoService arquivoService, string nomeDoArquivo, IEnumerable<Rota> rotas, double combustivel);
        IEnumerable<Rota> LerRelatorio(IArquivoService arquivoService, string nomeDoArquivo);
        Tuple<IEnumerable<Rota>, double> LerRelatorioComCombustivel(IArquivoService arquivoService, string nomeDoArquivo);
        double ObterCombustivelDisponivel(Queue<string> queue);
        List<Rota> ObterRotas(Queue<string> linhas, IEnumerable<Veiculo> veiculos);
        List<Trecho> ObterTrechos(Queue<string> linhas, Roteiro roteiro);
        IEnumerable<Veiculo> ObterVeiculos(Queue<string> linhas);
    }
}