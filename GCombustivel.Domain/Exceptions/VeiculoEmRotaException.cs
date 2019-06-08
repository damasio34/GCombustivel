using System;

namespace Damasio34.GCombustivel.Dominio.Exceptions
{
   public class VeiculoEmRotaException : Exception
    {
        public VeiculoEmRotaException() : base("O veículo deve possuir apenas uma rota por dia.") { }
    }
}
