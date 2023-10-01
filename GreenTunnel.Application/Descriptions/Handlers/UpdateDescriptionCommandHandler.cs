using AutoMapper;
using GreenTunnel.Application.Description.Commands.UpdateDescription;
using GreenTunnel.Application.InputTypes.Commands.UpdateInputType;
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

namespace GreenTunnel.Application.Descriptions.Handlers
{
    public class UpdateDescriptionCommandHandler : IRequestHandler<UpdateDescriptionCommand, CqrsResponseViewModel>
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IMapper _mapper;

        public UpdateDescriptionCommandHandler(IDescriptionRepository descriptionRepository,
            IMapper mapper)
        {
            _descriptionRepository = descriptionRepository;
            _mapper = mapper;
        }

        public async Task<CqrsResponseViewModel> Handle(UpdateDescriptionCommand request, CancellationToken cancellationToken)
        {
            var description = await _descriptionRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);
            if (description == null)
            {
                return null;
            }
            description.UpdatedDate = DateTime.UtcNow;
            description.Name = request.Model.Name;
            description.Order = request.Model.Order;
            description.CategoryId = request.Model.CategoryId;
            description.InputTypeId = request.Model.InputTypeId;
            _descriptionRepository.Update(description);
            return new UpdateDescriptionCommandResponseModel
            {
                DescriptionId = request.Model.Id,
            };
        }
    }
}
