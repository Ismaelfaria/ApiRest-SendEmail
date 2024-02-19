
using FluentValidation;
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
        private readonly IValidator<CandidatoInputModel> _inputValidator;
        public ControllerCandidato(IServiceCandidato serviceCandidato, IServiceEmail mailService, IValidator<CandidatoInputModel> inputValidator)
        {
            _serviceCandidato = serviceCandidato;
            _mailService = mailService;
            _inputValidator = inputValidator;
        }

        string subject = "EMPRESA-ISMAEL";

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
                return StatusCode(404, $"Erro do GetAll(Controller): {ex.Message}");
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
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
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
                return StatusCode(404, $"Erro do GetByEmail(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] CandidatoInputModel candidato)
        {
            try
            {
                var validatorResult = _inputValidator.Validate(candidato);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }

                var newRegister = _serviceCandidato.Create(candidato);

                _mailService.SendEmail(candidato.Email, subject, "Seu cadastro foi realizado");

                return CreatedAtAction(nameof(GetById), new { id = newRegister.Id }, candidato);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CandidatoInputModel candidato)
        {
            try
            {
                _serviceCandidato.Update(id, candidato);
                _mailService.SendEmail(candidato.Email, subject, "Seu cadastro foi atualizado");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do Put(Controller): {ex.Message}");
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
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
