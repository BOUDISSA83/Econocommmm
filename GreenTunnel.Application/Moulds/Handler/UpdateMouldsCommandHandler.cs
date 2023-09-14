using AutoMapper;
using DAL.Core;
using GreenTunnel.Application.Moulds.Commands.UpdateMoulds;
using GreenTunnel.Application.User.Commands.UpdateUser;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Moulds.Handlers.Commands
{
    public class UpdateMouldsCommandHandler : IRequestHandler<UpdateMouldsCommand ,bool>
    {
        private readonly IMapper _mapper;
        private readonly IMouldsRepository _mouldsRepository;
        public UpdateMouldsCommandHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            IMouldsRepository mouldsRepository)
        {
            _mapper = mapper;
            _mouldsRepository = mouldsRepository;
        }
        public async Task<bool> Handle(UpdateMouldsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _mouldsRepository.Update(_mapper.Map<GreenTunnel.Core.Entities.Moulds>(request._moulds));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
