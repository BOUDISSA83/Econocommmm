using GreenTunnel.Application.InputTypes.Commands.UpdateInputType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.InputTypes.Handlers
{
    public class UpdateInputTypeCommandHandler : IRequestHandler<UpdateInputTypeCommand, CqrsResponseViewModel>
    {
        private readonly IInputTypeRepository _inputTypeRepository;

        public UpdateInputTypeCommandHandler(IInputTypeRepository inputTypeRepository)
        {
            _inputTypeRepository = inputTypeRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(UpdateInputTypeCommand request, CancellationToken cancellationToken)
        {
            var inputType = await _inputTypeRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);
            if (inputType == null)
            {
                return null;
            }
            inputType.UpdatedDate = DateTime.UtcNow;
            inputType.Name = request.Model.Name;
            inputType.Value = request.Model.Value;

            _inputTypeRepository.Update(inputType);
            return new UpdateInputTypeCommandResponseModel
            {
                InputTypeId = request.Model.Id,
            };
        }
    }
}
