using GreenTunnel.Application.InputType.Commands.CreateInputType;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputTypes.Handlers
{
    public class CreateInputTypeCommandHandler : IRequestHandler<CreateInputTypeCommand, CqrsResponseViewModel>
    {
        private readonly IInputTypeRepository _inputTypeRepository;

        public CreateInputTypeCommandHandler(IInputTypeRepository inputTypeRepository)
        {
            _inputTypeRepository = inputTypeRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(CreateInputTypeCommand request, CancellationToken cancellationToken)
        {
            var inputTypeModel = new InputType()
            {
                Name = request.Model.Name,
                Value = request.Model.Value,
            };
            var inputTypeResult = _inputTypeRepository.AddAsync(inputTypeModel);
            return new CreateInputTypeCommandResponseModel
            {
                InputTypeId = inputTypeModel.Id,
            };
        }
    }
}
