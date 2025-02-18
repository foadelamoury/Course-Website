﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DatabaseFacade? Database { get; }

    DbSet<Country> Countries { get; }// Lookup
    DbSet<Course> Courses { get; }
    DbSet<CourseCategory> CourseCategories { get; } // Lookup
    DbSet<Student> Students { get; }
    DbSet<StudentCourse> StudentCourses { get; }






    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
