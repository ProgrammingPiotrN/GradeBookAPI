using GradeBook.Domain.Abstractions;
using GradeBook.Domain.Entities;
using GradeBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Infrastructure.Repositories;

internal class StudentRepository : IStudentRepository
{
    private readonly GradeBookDbContext _gradeBookDbContext;

    public StudentRepository(GradeBookDbContext gradeBookDbContext)
    {
        _gradeBookDbContext = gradeBookDbContext;
    }

    public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _gradeBookDbContext.Students.ToListAsync(cancellationToken);
    }

    public async Task<Student> GetByEamilAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _gradeBookDbContext.Students.SingleOrDefaultAsync(s => s.Email == email, cancellationToken);
    }

    public async Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _gradeBookDbContext.Students.SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public Task<bool> IsAlreadyExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return _gradeBookDbContext.Students.AnyAsync(s => s.Email == email, cancellationToken);
    }

    public void AddStudent(Student student)
    {
        _gradeBookDbContext.Students.Add(student);
    }

    public void DeleteStudent(Student student)
    {
        _gradeBookDbContext.Students.Remove(student);
    }

    public void UpdateStudent(Student student)
    {
        _gradeBookDbContext.Students.Update(student);
    }
}
