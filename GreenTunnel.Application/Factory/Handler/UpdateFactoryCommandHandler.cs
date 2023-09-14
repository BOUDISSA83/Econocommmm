using GreenTunnel.Application.Factory.Commands.UpdateFactory;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Handler
{
    public class UpdateFactoryCommandHandler : IRequestHandler<UpdateFactoryCommand, CqrsResponseViewModel>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IWorkplaceRepository _workplaceRepository;

        public UpdateFactoryCommandHandler(IFactoryRepository factoryRepository, IWorkplaceRepository workplaceRepository)
        {
            _factoryRepository = factoryRepository;
            _workplaceRepository = workplaceRepository;
        }

        public async Task<CqrsResponseViewModel> Handle(UpdateFactoryCommand request, CancellationToken cancellationToken)
        {
            var factory = await _factoryRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);

            if (factory == null)
            {
                return null;
            }

            factory.Name = request.Model.Name;
            factory.Email = request.Model.Email;
            factory.Address = request.Model.Address;
            factory.Description = request.Model.Description;
            factory.Mobile = request.Model.Mobile;
            factory.Phone = request.Model.Phone;
            factory.Support = request.Model.Support;
            factory.UpdatedDate = DateTime.UtcNow;
            factory.UpdatedBy = request.Model.UserId; // Set the updated by user ID

            factory.Workplaces.Clear(); // Clear existing workplaces

            //foreach (var workplaceId in request.Model.WorkplaceIds)
            //{
            //    var existingWorkplace = await _workplaceRepository.GetByIdAsync(workplaceId);

            //    if (existingWorkplace != null)
            //    {
            //        factory.Workplaces.Add(existingWorkplace);
            //    }
            //}

             _factoryRepository.Update(factory);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }

}
