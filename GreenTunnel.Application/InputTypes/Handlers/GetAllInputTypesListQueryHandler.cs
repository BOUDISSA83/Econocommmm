using AutoMapper;
using GreenTunnel.Application.InputTypes.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.InputTypes.Handlers
{
    public class GetAllInputTypesListQueryHandler:IRequestHandler<GetAllInputTypesListQuery, List<GetInputTypesListResponseModel>>
    {
        private readonly IInputTypeRepository _inputTypeRepository;
        private readonly IMapper _mapper;

        public GetAllInputTypesListQueryHandler(IInputTypeRepository inputTypeRepository,
            IMapper mapper)
        {
            _inputTypeRepository = inputTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetInputTypesListResponseModel>> Handle(GetAllInputTypesListQuery request, CancellationToken cancellationToken)
        {
            var inputTypesList = await _inputTypeRepository.GetAllAsync();
            var inputTypesViewModel = _mapper.Map<List<GetInputTypesListResponseModel>>(inputTypesList);
            return inputTypesViewModel;
        }
    }
}
