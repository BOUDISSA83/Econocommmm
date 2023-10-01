using GreenTunnel.Application.Description.Commands.DeleteDescription;
using GreenTunnel.Application.InputTypes.Commands.DeleteInputType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Descriptions.Handlers
{
    internal class DeleteDescriptionCommandHandler : IRequestHandler<DeleteDescriptionCommand, CqrsResponseViewModel>
    {
        private readonly IDescriptionRepository _descriptionRepository;

        public DeleteDescriptionCommandHandler(IDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(DeleteDescriptionCommand request, CancellationToken cancellationToken)
        {
            var inputType = await _descriptionRepository.GetSingleOrDefaultAsync(f => f.Id == request.InputTypeId);

            if (inputType == null)
            {
                return null;
            }

            _descriptionRepository.Remove(inputType);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
