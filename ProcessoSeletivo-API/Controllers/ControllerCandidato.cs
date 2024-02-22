
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivo_API.ConteudoHTML;
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
        MenssageHtmlForSendingEmail mensageOfConfimation = new MenssageHtmlForSendingEmail();

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allRegister = _serviceCandidato.FindAll();

                return Ok(allRegister);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Não tem registros: {ex.Message}");
            }
        }

        [HttpGet("api/candidato/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var Register = _serviceCandidato.FindById(id);

                return Ok(Register);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Usuario não encontrado: {ex.Message}");
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                var Register = _serviceCandidato.FindByEmail(email);

                return Ok(Register);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Usuario não encontrado: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] CandidatoInputModel candidato)
        {
            try
            {
                var newRegister = _serviceCandidato.Create(candidato);

                _mailService.SendEmail(candidato.Email, subject, mensageOfConfimation.message);

                return CreatedAtAction(nameof(GetById), new { id = newRegister.Id }, candidato);
            }
            catch( ValidationException ex)
            {
                return BadRequest(new {errors = ex.Errors.Select(e => e.ErrorMessage)});
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro de criação por parte do servidor(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CandidatoInputModel candidato)
        {
            try
            {
                _serviceCandidato.Update(id, candidato);
                _mailService.SendEmail(candidato.Email, subject, mensageOfConfimation.messageUpdate);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro de atualização por parte do servidor(Controller): {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _serviceCandidato.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no delete(Controller): {ex.Message}");
            }
        }
    }
}
