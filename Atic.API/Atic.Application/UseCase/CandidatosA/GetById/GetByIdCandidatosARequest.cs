using Atic.Domain.Errors;
using Flunt.Notifications;
using MediatR;

namespace Atic.Application.UseCase.CandidatosA.GetById
{
    public class GetByIdCandidatosARequest : Notifiable, IRequest<ApiResponse<GetByIdCandidatosAResponse>>
    {
        public string Fecha { get; set; }
    }
}
