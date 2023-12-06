using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteTracker.Core.Exceptions
{
    public class AlreadyExistentException : Exception
    {
        public AlreadyExistentException(string property) : base($"A entidade não foi criada, pois já existe outra entidade com o mesmo {property}")
        {
        }
    }
}
