﻿using Application.Features.StudentCourseTable.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.StudentCourseTable.Commands.Update
{
    public class UpdateStudentCourseCommand : StudentCourseDTO, IRequest<long>
    {
        public UpdateStudentCourseCommand()
        { }


        public UpdateStudentCourseCommand(StudentCourseDTO dto)
        {
            Id = dto.Id;

        }
        public class Handler : IRequestHandler<UpdateStudentCourseCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.StudentCourse entity = new Domain.Entities.StudentCourse
                {
                    Id = request.Id,


                };


                await _context.StudentCourses.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}