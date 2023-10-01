using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Core.Interfaces;
using MediatR;

namespace GreenTunnel.Application.Moulds.Handler;

public class GetDuplicateMouldQueryHandler : IRequestHandler<GetDuplicateMouldQuery, bool>
{
    private readonly IMouldsRepository _mouldRepository;

    public GetDuplicateMouldQueryHandler(IMouldsRepository mouldRepository)

    {
        _mouldRepository = mouldRepository;
    }
    public async Task<bool> Handle(GetDuplicateMouldQuery request, CancellationToken cancellationToken)
    {
        var factory = await _mouldRepository.GetSingleOrDefaultAsync(f => f.Name.ToLower() == request.Name.ToLower());

        if (factory == null)
        {
            // Handle factory not found
            // Return an appropriate response or throw an exception
            return false;
        }


        return true;
    }
}