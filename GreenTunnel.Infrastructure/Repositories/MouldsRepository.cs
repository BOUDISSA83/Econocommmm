

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GreenTunnel.Infrastructure.Interfaces;
using GreenTunnel.Core.Repositories.Interfaces;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class MouldsRepository : Repository<Moulds>, IMouldsRepository
    {

        public MouldsRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }


        private ApplicationDbContext _appContext;
    }
}
