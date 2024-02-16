
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivo_API.Models;
using ProcessoSeletivo_API.Service;

namespace ProcessoSeletivo_API.Controllers
{
    [Route("api/Processo-Seletivo")]
    [ApiController]
    public class ControllerCandidato : ControllerBase
    {
        private readonly IServiceCandidato _serviceCandidato;
        private readonly IServiceEmail _mailService;
        public ControllerCandidato(IServiceCandidato serviceCandidato, IServiceEmail mailService)
        {
            _serviceCandidato = serviceCandidato;
            _mailService = mailService;
        }

        string subject = "EMPRESA-ISMAEL";

        [HttpGet]
        public IActionResult GetAll()
        {
            var allRegister = _serviceCandidato.FindAll();

            return Ok(allRegister);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Register = _serviceCandidato.FindById(id);

            return Ok(Register);
        }

        [HttpPost]
        public IActionResult Create(CandidatoInputModel candidato)
        {
            var newRegister = _serviceCandidato.Create(candidato);
            _mailService.SendEmail(candidato.Email.Email, subject, "Seu cadastro foi realizado");

            return CreatedAtAction(nameof(GetById), new { id = newRegister.Id }, candidato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CandidatoInputModel candidato)
        {
            _serviceCandidato.Update(id, candidato);
            _mailService.SendEmail(candidato.Email.Email, subject, "Seu cadastro foi atualizado");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _serviceCandidato.Delete(id);

            return NoContent();
        }
    }
}
