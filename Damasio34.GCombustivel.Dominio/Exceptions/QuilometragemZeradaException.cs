using System;

namespace Damasio34.GCombustivel.Dominio.Exceptions
{
   public class QuilometragemZeradaException : Exception
    {
        public QuilometragemZeradaException() : base("A quilometragem está zerada") { }
    }
}
