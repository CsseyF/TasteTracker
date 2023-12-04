using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteTracker.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("A entidade solicitada não foi encontrada")
        {
            // You can add any additional initialization logic here.
        }
    }
}
