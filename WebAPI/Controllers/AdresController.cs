using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : BaseApiController
    {
        private IIlService _illerService;
        private IIlceService _ilcelerService;
        private IMahalleService _mahallelerService;
        private ICsbmService _csbmService;
        private IMapKeyService _mapKeyService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="illerService"></param>
        /// <param name="ilcelerService"></param>
        /// <param name="mahallelerService"></param>
        /// <param name="csbmService"></param>
        /// <param name="netGsmSistemOnayKodService"></param>
        /// <param name="mapKeyService"></param>
        public AdresController(
            IIlService illerService,
            IIlceService ilcelerService,
            IMahalleService mahallelerService,
            ICsbmService csbmService, INetGsmSistemOnayKodService netGsmSistemOnayKodService,
            IMapKeyService mapKeyService)
        {
            _illerService = illerService;
            _ilcelerService = ilcelerService;
            _mahallelerService = mahallelerService;
            _csbmService = csbmService;
            _mapKeyService = mapKeyService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet("illeriGetir")]
        public IActionResult illeriGetir()
        {
            var result = _illerService.ilListele();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ilKodu"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet("ilceleriGetir")]
        public IActionResult ilceleriGetir(int ilKodu)
        {
            var result = _ilcelerService.ilceListele(ilKodu);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ilceKodu"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet("mahalleleriGetir")]
        public IActionResult mahalleleriGetir(int ilceKodu)
        {
            var result = _mahallelerService.mahalleListele(ilceKodu);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mahalleKodu"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet("csbmleriGetir")]
        public IActionResult csbmleriGetir(int mahalleKodu)
        {
            var result = _csbmService.csbmListele(mahalleKodu);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet("konumdanAdresGetir")]
        public IActionResult konumdanAdresGetir(string lat, string lng)
        {
            var result = _mapKeyService.konumdanAdresGetir(lat, lng);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }

}
