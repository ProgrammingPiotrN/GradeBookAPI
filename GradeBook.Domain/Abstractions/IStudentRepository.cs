using GradeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Domain.Abstractions;

public interface IStudentRepository
{
    //Zwracanie listy wszystkich studentów asynchronicznie
    //CancellationToken pozwala na anulowanie operacji
    Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);

    //Pobieranie studenta po identyfikatorze asynchronicznie
    Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    //Pobieranie studenta po adresie email asynchronicznie
    Task<Student> GetByEamilAsync(string email, CancellationToken cancellationToken = default);

    //Czy student znajduje się w systemie
    Task<bool> IsAlreadyExistsAsync(string email, CancellationToken cancellationToken = default);

    //Dodoawanie studenta
    void AddStudent(Student student);

    //Usunięcie studenta z ewidencji
    void DeleteStudent(Student student);

    //Aktualizowanie danych studenta
    void UpdateStudent(Student student);
}
