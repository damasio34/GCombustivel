using Damasio34.GCombustivel.Dominio.Exceptions;
using System;
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

        public int Dia { get; }
        public List<Roteiro> Roteiros { get; } = new List<Roteiro>();

        public double ConsumoMedio => this.Roteiros.Sum(x => x.ConsumoMedio);

        public Roteiro AdicionarVeiculo(Veiculo veiculo)
        {
            if (this.Roteiros.Any(p => p.Veiculo.Codigo.Equals(veiculo.Codigo)))
                throw new VeiculoEmRotaException();

            var roteiro = new Roteiro(veiculo);
            this.Roteiros.Add(roteiro);

            return roteiro;
        }
        public void AdicionarTrecho(Veiculo veiculo, string cidade, double quilometragem)
        {
            var roteiro = this.Roteiros.SingleOrDefault(p => p.Veiculo.Codigo.Equals(veiculo.Codigo));
            if (roteiro == null) roteiro = this.AdicionarVeiculo(veiculo);

            roteiro.AdicionarTrecho(cidade, quilometragem);
        }
    }
}
