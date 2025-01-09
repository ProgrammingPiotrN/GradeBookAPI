using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Domain.Exceptions;

public abstract class GradeBookExceptions : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    public GradeBookExceptions(string message) : base(message)
    {
        
    }
}
