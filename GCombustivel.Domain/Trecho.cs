using Damasio34.GCombustivel.Dominio.Exceptions;

namespace Damasio34.GCombustivel.Dominio
{
    public class Trecho
    {
        public Trecho(Rota rota, Veiculo veiculo, string codigo, double quilometragem)
        {
            if (quilometragem <= 0) throw new QuilometragemZeradaException();
            this.Quilometragem = quilometragem;

            veiculo.Trechos.Add(this);
            this.Codigo = codigo;
            this.Rota = rota;
        }

        public Rota Rota { get; set; }
        public double Quilometragem { get; private set; }
        public string Codigo { get; }        
    }
}
