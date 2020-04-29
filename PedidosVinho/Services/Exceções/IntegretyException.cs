using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosVinho.Services.Exceções
{
    public class IntegretyException : ApplicationException
    {
        public IntegretyException(String message) : base(message)
        {
        }
    }
}
