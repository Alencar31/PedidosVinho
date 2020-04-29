using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosVinho.Services.Exceções
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(String message) : base(message)
        {
        }
    }
}
