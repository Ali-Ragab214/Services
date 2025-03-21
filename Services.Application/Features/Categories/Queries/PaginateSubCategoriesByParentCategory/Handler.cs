﻿using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Application.Features.Categories.Queries.PaginateParentCategories;
using Services.Domain.Abstraction;
using Services.Shared.Responses;
using Services.Shared.ValidationMessages;

namespace Services.Application.Features.Categories.Queries.PaginateSubCategoriesByParentCategory
{
    public sealed class PaginateSubCategoriesByParentCategoryHandler(
        ICategoryRepository _categoryRepository
    )
        : IRequestHandler<
            PaginateSubCategoriesByParentCategoryQuery,
            ResponseOf<PaginateSubCategoriesByParentCategoryResults>
        >
    {
        public async Task<ResponseOf<PaginateSubCategoriesByParentCategoryResults>> Handle(
            PaginateSubCategoriesByParentCategoryQuery request,
            CancellationToken cancellationToken
        )
        {
            int page = request.page == 0 ? 1 : request.page;
            int pagesize = request.pageSize == 0 ? 10 : request.pageSize;

            IReadOnlyCollection<SubCategories> result = await _categoryRepository.PaginateAsync(
                page,
                pagesize,
                c => new SubCategories(c.Id, c.Name, c.SubCategories.Count),
                c =>
                    c.ParentId == request.parentCategory
                    && (c.Id == request.Id || request.Id == null),
                c => c.Include(sub => sub.SubCategories),
                cancellationToken
            );

            return new()
            {
                Message = ValidationMessages.Success,
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Result = new(
                    page,
                    pagesize,
                    (int)Math.Ceiling(result.Count / (double)pagesize),
                    result
                ),
            };
        }
    }
}
