using GreenTunnel.Application.Factory.Commands.CreateFactory;
using GreenTunnel.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Application.Moulds.Commands.CreateMoulds;

namespace Moulds.Handler
{
    public class CreateMouldsCommandHandler : IRequestHandler<CreateMouldsCommand, CqrsResponseViewModel>
    {
        private readonly IMouldsRepository _mouldsRepository;

        public CreateMouldsCommandHandler(
            IMouldsRepository mouldsRepository)
        {
            _mouldsRepository = mouldsRepository;
        }
        // Application/Factories/DTOs/FactoryDto.cs
        

        public async Task<CqrsResponseViewModel> Handle(CreateMouldsCommand request, CancellationToken cancellationToken)
        {

            var mouldsModel = new GreenTunnel.Core.Entities.Moulds()
            {
               // Id = 1,
                Name = request.Model.Name,
                Type = request.Model.Type,
                WorkspaceId = request.Model.WorkspaceId,
                //Descriptions = request.Model.Description, Will work on this at Description Model
                UpdatedDate = DateTime.UtcNow,
                UserId = request.Model.UserId,
                CreatedBy =request.Model.UserId.ToString(),
                UpdatedBy = request.Model.UserId.ToString(),
                CreatedDate = DateTime.UtcNow
                // Set other properties
            };
            try
            {
                _mouldsRepository.Add(mouldsModel);
            }
            catch (Exception ex)
            {

            }
            return new CreateMouldsCommandResponseModel
            {
                 MouldsId = mouldsModel.Id
            };
        }
    }
}
