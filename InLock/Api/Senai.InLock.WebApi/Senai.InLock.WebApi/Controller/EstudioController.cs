using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repository;

namespace Senai.InLock.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IEnumerable<EstudioDomain> Get()
        {
            return _estudioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }
    }
}