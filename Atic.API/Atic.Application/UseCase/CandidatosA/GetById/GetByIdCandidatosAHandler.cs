using Atic.Domain.DTO;
using Atic.Domain.Entities;
using Atic.Domain.Errors;
using Atic.Domain.Interface.Command;
using Atic.Domain.Interface.Queries;
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
        private readonly IGenericsCommand _genericsCommand;
        private readonly IGenericsQuery _genericsQuery;

        public GetByIdCandidatosAHandler(IGenericsCommand genericsCommand, IGenericsQuery genericsQuery)
        {
            _genericsCommand = genericsCommand;
            _genericsQuery = genericsQuery;
        }

        public async Task<ApiResponse<GetByIdCandidatosAResponse>> Handle(GetByIdCandidatosARequest request, CancellationToken cancellationToken)
        {
            try
            {
                var registration = await _genericsQuery.GetById<DataCandidatosA>("candidatos_A", "Fecha", request.Fecha);
                var DTO = new CandidatosADTO
                {
                    Fecha = registration.Fecha,
                    AnemometroTs231 = registration.AnemometroTs231,
                    DireccionVientoTs232 = registration.DireccionVientoTs232,
                    HumedadRelativaTs251 = registration.HumedadRelativaTs251,
                    NivelVegapuls61 = registration.NivelVegapuls61,
                    PluviometroTs221 = registration.PluviometroTs221,
                    PresionAtmTs290 = registration.PresionAtmTs290,
                    TemperaturaTs251 = registration.TemperaturaTs251,
                    TensionBateria = registration.TensionBateria,
                    VoltajeMax5V = registration.VoltajeMax5V
                }; 
                var response = new GetByIdCandidatosAResponse
                {
                    candidatosADTO = DTO
                };
                return new ApiResponse<GetByIdCandidatosAResponse>(response);
            }
            catch (Exception ex)
            {
                request.AddNotification(nameof(request), MessageApiError.ExampleMessage + ex.Message);
                return new ApiResponse<GetByIdCandidatosAResponse>(request.Notifications, HttpStatusCode.BadRequest);
            }
        }
    }
}	
