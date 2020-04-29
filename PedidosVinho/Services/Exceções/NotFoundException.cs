using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosVinho.Services.Exceções
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
