using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Service
{
    public interface ICambioService
    {
        decimal Calcular(string moedaOrigem, string moedaDestino, decimal valor);
    }
}
