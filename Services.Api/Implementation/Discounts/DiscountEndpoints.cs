﻿using MediatR;
using Services.Api.Abstraction;
using Services.Application.Features.Discounts.Commands.Create;
using Services.Application.Features.Discounts.Commands.Delete;
using Services.Application.Features.Discounts.Commands.Update;
using Services.Application.Features.Discounts.Queries.GetById;
using Services.Application.Features.Discounts.Queries.Paginate;

namespace Services.Api.Implementation.Discounts
{
    public sealed class DiscountEndpoints : IEndpoint
    {
        public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            RouteGroupBuilder group = endpoints.MapGroup("/Discounts").WithTags("Discounts");

            group.MapPost(
               "CreateAsync/",
               async (
                  CreateDiscountCommand Command,
                   ISender sender,
                   CancellationToken cancellationToken
               ) => Results.Ok(await sender.Send(Command, cancellationToken))
           );

            group.MapPut(
                "UpdateAsync/",
                async (
                    UpdateDiscountCommand Command,
                    ISender sender,
                    CancellationToken cancellationToken
                ) => Results.Ok(await sender.Send(Command, cancellationToken))
            );

            group.MapDelete(
                "DeleteAsync/{id}",
                async (Guid id, ISender sender, CancellationToken cancellationToken) =>
                    Results.Ok(await sender.Send(new DeleteDiscountCommand(id), cancellationToken))
            );


            group.MapGet(
                "GetByIdAsync/{id}",
                async (Guid id, ISender sender, CancellationToken cancellationToken) =>
                    Results.Ok(await sender.Send(new GetDiscountByIdQuery(id), cancellationToken))
            );

            group.MapPost(
                "PaginateAsync",
                async (
                    PaginateDiscountsQuery query,
                    ISender sender,
                    CancellationToken cancellationToken
                ) => Results.Ok(await sender.Send(query, cancellationToken))
            );
        }
    }
}
