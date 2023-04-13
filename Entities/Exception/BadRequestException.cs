using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exception
{
    public abstract class BadRequestException : System.Exception // newlenemeyen base class. 
    {
        protected BadRequestException(string message): base(message) 
        {

        }
    }
}
