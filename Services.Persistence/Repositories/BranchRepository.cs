﻿using System.Threading;
using Microsoft.EntityFrameworkCore;
using Services.Domain.Abstraction;
using Services.Domain.Entities;
using Services.Persistence.Data;

namespace Services.Persistence.Repositories
{
    public sealed class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly ServiceDbContext _context;

        public BranchRepository(ServiceDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _context
                .Set<Branch>()
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

        public async ValueTask<Branch> GetByIdAsync(Guid Id, CancellationToken cancellationToken) =>
            await _context
                .Set<Branch>()
                .AsTracking()
                .FirstAsync(id => id.Id == Id, cancellationToken);

        public async ValueTask<Branch> GetByNameAsync(
            string Name,
            CancellationToken cancellationToken
        ) =>
            await _context
                .Set<Branch>()
                .AsTracking()
                .FirstAsync(id => id.Name == Name, cancellationToken);
    }
}
