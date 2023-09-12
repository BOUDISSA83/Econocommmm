

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.Interfaces;
using GreenTunnel.Infrastructure.Repositories;
using System;
using System.Linq;

namespace GreenTunnel.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IFactoryRepository _factories;
        private IWorkSpaceRepository _workspaces;
        private IWorkplaceRepository _workplaces;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IFactoryRepository Factories
        {
            get
            {
                _factories ??= new FactoryRepository(_context);

                return _factories;
            }
        }

        public IWorkSpaceRepository Workspaces
        {
            get
            {
                _workspaces ??= new WorkspaceRepository(_context);

                return _workspaces;
            }
        }

        public IWorkplaceRepository Workplaces
        {
            get
            {
                _workplaces ??= new WorkplacesRepository(_context);

                return _workplaces;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
