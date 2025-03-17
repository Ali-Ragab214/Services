﻿using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Domain.Abstraction;
using Services.Shared.Exceptions;
using Services.Shared.Responses;
using Services.Shared.ValidationMessages;

namespace Services.Application.Features.Workers.Queries.GetWorkersBasedOnStatus
{
    public sealed record GetWorkerPaginateHandler
        : IRequestHandler<GetWorkerStatusPaginateQuery, ResponseOf<GetWorkerStatusPaginateResult>>
    {
        private readonly IWorkerRepository _workerRepository;

        public GetWorkerPaginateHandler(IWorkerRepository workerRepository) =>
            _workerRepository = workerRepository;

        public async Task<ResponseOf<GetWorkerStatusPaginateResult>> Handle(
            GetWorkerStatusPaginateQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                int page = request.page == 0 ? 1 : request.page;
                int pagesize = request.pagesize == 0 ? 10 : request.pagesize;

                IReadOnlyCollection<GetWorkers>? result = await _workerRepository.PaginateAsync(
                    page,
                    pagesize,
                    w => new GetWorkers(w.UserId, w.User.Name, w.Status),
                    w =>
                        w.Status == request.status
                        && (w.UserId == request.WorkerId || request.WorkerId == null),
                    w => w.Include(u => u.User)
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
            catch
            {
                throw new DatabaseTransactionException(ValidationMessages.Database.Error);
            }
        }
    }
}
