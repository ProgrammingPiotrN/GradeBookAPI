using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Domain.Exceptions;

public class StudentNotFoundException : GradeBookExceptions
{
    public int Id { get; set; }
    public StudentNotFoundException(int id) : base($"Student with Id {id} was not found.")
        => Id = id;

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
