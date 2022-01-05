using Atic.API.Presenters;
using Atic.Application.UseCase.CandidatosA.GetById;
using Flunt.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosAController : ControllerBase
    {
        private readonly IApiRestPresenter _presenter;
        private readonly IMediator _mediator;

        public CandidatosAController(IApiRestPresenter presenter, IMediator mediator)
        {
            _presenter = presenter;
            _mediator = mediator;
        }

        [Route("/Atic/CandidatosA/{Id}")]
        [HttpGet()]
        [ProducesResponseType(typeof(GetByIdCandidatosAResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Notification>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Notification>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCandidatosAId(string Id)
        {
            return _presenter.GetActionResult(await _mediator.Send(new GetByIdCandidatosARequest { Fecha = Id }));
        }
    }
}
