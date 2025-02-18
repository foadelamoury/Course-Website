﻿using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CoursesCategory.Queries.GetAll
{
    public class GetAllCourseCategoriesQuery : IRequest<IEnumerable<CourseCategoryDTO>>
    {
        public class Handler : IRequestHandler<GetAllCourseCategoriesQuery, IEnumerable<CourseCategoryDTO>>
        {

            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CourseCategoryDTO>> Handle(GetAllCourseCategoriesQuery request, CancellationToken cancellationToken)
            {
                var courseCategories = await _context.CourseCategories.Select(x =>
                      new CourseCategoryDTO
                      {
                          Id = x.Id,
                          NameA = x.NameA,
                          NameE = x.NameE,
                          SortIndex = x.SortIndex,
                          Focus = x.Focus,
                          Active = x.Active

                      }
                  ).ToListAsync();

                return courseCategories;
            }
        }
    }

}