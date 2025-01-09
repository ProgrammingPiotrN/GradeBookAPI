using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Domain.Exceptions;

public class StudentAlreadyExistsException : GradeBookExceptions
{
    public string Email { get; set; }
    public StudentAlreadyExistsException(string email) : base($"Student with email {email} already exists.")
        => Email = email;

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
