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
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles ="1")]
        [HttpGet]
        public IEnumerable<UsuarioDomain> Get()
        {
            return _usuarioRepository.Listar();
        }
        
        [HttpPost]
        public IActionResult Cadastrar(UsuarioDomain novoJogo)
        {
            _usuarioRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }
    }
}