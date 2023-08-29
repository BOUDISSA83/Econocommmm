

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Interfaces;
using GreenTunnel.Infrastructure.Repositories;
using GreenTunnel.Repositories.Interfaces;
using System;
using System.Linq;

namespace GreenTunnel.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IFactoryRepository _factories;
        private IWorkspaceRepository _workspaces;
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

        public IWorkspaceRepository Workspaces
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
                _workplaces ??= new WorkplaceRepository(_context);

                return _workplaces;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
