using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IBaseService<Usuario> _usuarioService;

        public UsuarioController(IBaseService<Usuario> usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUsuarioModel usuario)
        {
            if (usuario == null)
                return NotFound();

            return Execute(() => _usuarioService.Add<CreateUsuarioModel, UsuarioModel, UsuarioValidator>(usuario));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUsuarioModel usuario)
        {
            if (usuario == null)
                return NotFound();

            return Execute(() => _usuarioService.Update<UpdateUsuarioModel, UsuarioModel, UsuarioValidator>(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _usuarioService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _usuarioService.Get<UsuarioModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _usuarioService.GetById<UsuarioModel>(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}