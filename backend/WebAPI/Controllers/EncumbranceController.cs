using Application.Encumbrances.Dtos;
using Application.Encumbrances.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EncumbranceController : BaseController
    {
        public EncumbranceController(IMediator mediator)
            : base(mediator) 
        { }

        [HttpGet]
        public async Task<IActionResult> GetEncumbrances([FromBody] EncumbrancesFilter filter)
        {
            IEnumerable<ShortEncumbranceDto> encumbrances = await Mediator.Send(new GetEncumbrancesQuery(filter));
            
            return encumbrances.Count() == 0
                ? NotFound()
                : Ok(encumbrances);
        }

        [HttpGet("/{id}/General")]
        public async Task<IActionResult> GetEncumbranceGeneralInfo(Guid id)
        {
            EncumbranceGeneralInfoDto generalInfo = await Mediator.Send(new GetEncumbranceGeneralInfoQuery(id));
            return generalInfo is null
                ? NotFound()
                : Ok(generalInfo);
        }

        [HttpGet("id")]
        [Route("/{id}/Tier")]
        public async Task<IActionResult> GetEncumbranceTierInfo(Guid id)
        {
            EncumbranceTierInfoDto tierInfo = await Mediator.Send(new GetEncumbranceTierInfoQuery(id));
            return tierInfo is null
                ? NotFound()
                : Ok(tierInfo);
        }

        [HttpGet("id")]
        [Route("/{id}/Debtor")]
        public async Task<IActionResult> GetEncumbranceDebtorInfo(Guid id)
        {
            EncumbranceDebtorInfoDto debtorInfo = await Mediator.Send(new GetEncumbranceDebtorInfoQuery(id));
            return debtorInfo is null
                ? NotFound()
                : Ok(debtorInfo);
        }

        [HttpGet("id")]
        [Route("/{id}/BasisDocument")]
        public async Task<IActionResult> GetEncumbranceBasisDocumentInfo(Guid id)
        {
            EncumbranceBasisDocumentInfoDto basisDocumentInfo = await Mediator.Send(new GetEncumbranceBasisDocumentInfoQuery(id));
            return basisDocumentInfo is null
                ? NotFound()
                : Ok(basisDocumentInfo);
        }

        [HttpGet("id")]
        [Route("/{id}/Terms")]
        public async Task<IActionResult> GetEncumbranceTermsInfo(Guid id)
        {
            EncumbranceTermsInfoDto termsInfo = await Mediator.Send(new GetEncumbranceTermsInfoQuery(id));
            return termsInfo is null
                ? NotFound()
                : Ok(termsInfo);
        }

        [HttpGet("id")]
        [Route("/{id}/AdditionalInfo")]
        public async Task<IActionResult> GetEncumbranceAdditionalInfo(Guid id)
        {
            EncumbranceAdditionalInfoDto additionalInfo = await Mediator.Send(new GetEncumbranceAdditionalInfoQuery(id));
            return additionalInfo is null
                ? NotFound()
                : Ok(additionalInfo);
        }
    }
}
