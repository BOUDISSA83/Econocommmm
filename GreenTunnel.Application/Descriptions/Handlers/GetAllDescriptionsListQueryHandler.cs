using AutoMapper;
using GreenTunnel.Application.Descriptions.Queries;
using GreenTunnel.Application.InputTypes.Queries;
using GreenTunnel.Core.Interfaces;
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
    public class GetAllDescriptionsListQueryHandler:IRequestHandler<GetAllDescriptionsListQuery, List<GetDescriptionsListResponseModel>>
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IMapper _mapper;

        public GetAllDescriptionsListQueryHandler(IDescriptionRepository descriptionRepository,
            IMapper mapper)
        {
            _descriptionRepository = descriptionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDescriptionsListResponseModel>> Handle(GetAllDescriptionsListQuery request, CancellationToken cancellationToken)
        {
            var inputTypesList = await _descriptionRepository.GetAllAsync();
            var inputTypesViewModel = _mapper.Map<List<GetDescriptionsListResponseModel>>(inputTypesList);
            return inputTypesViewModel;
        }
    }
}
