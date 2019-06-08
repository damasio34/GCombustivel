using Damasio34.GCombustivel.Dominio.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Damasio34.GCombustivel.Dominio
{
    public class Veiculo
    {
        public Veiculo(int codigo, int quilometroPorLitro)
        {
            this.Codigo = codigo;
            this.QuilometroPorLitro = quilometroPorLitro;
        }

        public int Codigo { get; }
        public int QuilometroPorLitro { get; }
        public IList<Rota> Rotas { get; private set; } = new List<Rota>();

        public void AdiconarRota(Rota rota)
        {
            if (this.Rotas.Any(p => p.Dia.Equals(rota.Dia))) throw new VeiculoEmRotaException();
            this.Rotas.Add(rota);
        }
    }
}
