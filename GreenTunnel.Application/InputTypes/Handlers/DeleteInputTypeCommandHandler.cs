using GreenTunnel.Application.InputTypes.Commands.DeleteInputType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.InputTypes.Handlers
{
    internal class DeleteInputTypeCommandHandler : IRequestHandler<DeleteInputTypeCommand, CqrsResponseViewModel>
    {
        private readonly IInputTypeRepository _inputTypeRepository;

        public DeleteInputTypeCommandHandler(IInputTypeRepository inputTypeRepository)
        {
            _inputTypeRepository = inputTypeRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(DeleteInputTypeCommand request, CancellationToken cancellationToken)
        {
            var inputType = await _inputTypeRepository.GetSingleOrDefaultAsync(f => f.Id == request.InputTypeId);

            if (inputType == null)
            {
                return null;
            }

            _inputTypeRepository.Remove(inputType);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
