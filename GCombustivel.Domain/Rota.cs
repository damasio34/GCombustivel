using System.Collections.Generic;

namespace Damasio34.GCombustivel.Dominio
{
    public class Rota
    {
        public Rota(int dia, Veiculo veiculo)
        {
            this.Dia = dia;
            this.AdicionarVeiculo(veiculo);
        }

        public int Dia { get; }
        public List<Veiculo> Veiculos { get; } = new List<Veiculo>();

        public double ConsumoMedio => 1;//this.Trechos.Sum(p => p.Quilometragem / p.Veiculo.QuilometroPorLitro);

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            //veiculo.Rotas.Add(this);
            this.Veiculos.Add(veiculo);            
        }
    }
}
