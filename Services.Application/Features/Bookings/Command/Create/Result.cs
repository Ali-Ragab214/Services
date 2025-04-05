﻿using Services.Domain.Entities;
using Services.Domain.Enums;

/*public static implicit operator CreateBranchResult(Branch branch) =>
            new(branch.Id, branch.Name, branch.Description, branch.Latitude, branch.Langitude);*/
namespace Services.Application.Features.Bookings.Command.Create
{
    public sealed record CreateBookingResult(
        Guid BookingId,
        DateTime CreateOn,
        BookingStatus Status,
        LocationType Location,
        Guid CustomerId,
        Guid WorkerId
    )
    {
        public static implicit operator CreateBookingResult(Booking booking) =>
            new(
                booking.Id,
                booking.CreateOn,
                booking.Status,
                booking.Location,
                booking.CustomerId,
                booking.WorkerId
            );
    }
}
