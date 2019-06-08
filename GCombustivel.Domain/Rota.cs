using System.Collections.Generic;
using System.Linq;

namespace Damasio34.GCombustivel.Dominio
{
    public class Rota
    {
        public Rota(int dia)
        {
            this.Dia = dia;            
        }

        public Rota(int dia, Veiculo veiculo) : this(dia)
        {
            this.Dia = dia;
            this.AdicionarVeiculo(veiculo);
        }

        public int Dia { get; }
        public List<Veiculo> Veiculos { get; } = new List<Veiculo>();

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculo.AdiconarRota(this);
            this.Veiculos.Add(veiculo);
        }

        public double ConsumoMedio => this.Veiculos.Sum(p => p.Trechos.Sum(a => a.Quilometragem) / p.QuilometroPorLitro);
    }
}
