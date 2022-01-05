using Atic.Domain.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atic.Application.UseCase.CandidatosA.GetById
{
    public class GetByIdCandidatosAHandler : IRequestHandler<GetByIdCandidatosARequest, ApiResponse<GetByIdCandidatosAResponse>>
    {
        public async Task<ApiResponse<GetByIdCandidatosAResponse>> Handle(GetByIdCandidatosARequest request, CancellationToken cancellationToken)
        {
            try
            {
                return new ApiResponse<GetByIdCandidatosAResponse>(new GetByIdCandidatosAResponse());
            }
            catch (Exception)
            {
                return new ApiResponse<GetByIdCandidatosAResponse>(request.Notifications, HttpStatusCode.BadRequest);
            }

        }

    }
}	
}