using GreenTunnel.Application.Description.Commands;
using GreenTunnel.Application.InputType.Commands.CreateInputType;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.Description;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descriptions.Handlers
{
    public class CreateDescriptionCommandHandler : IRequestHandler<CreateDescriptionCommand, CqrsResponseViewModel>
    {
        private readonly IDescriptionRepository  _descriptionRepository;

        public CreateDescriptionCommandHandler(IDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(CreateDescriptionCommand request, CancellationToken cancellationToken)
        {
            var descriptionModel = new Description()
            {
                Name = request.Model.Name,
                CreatedDate = DateTime.UtcNow,
                CategoryId = request.Model.CategoryId,
                InputTypeId = request.Model.InputTypeId,
                Order = request.Model.Order,

            };
            var descriptionResult = _descriptionRepository.AddAsync(descriptionModel);
            return new CreateDescriptionCommandResponseModel
            {
                InputTypeId = descriptionResult.Id,
            };
        }
    }
}
