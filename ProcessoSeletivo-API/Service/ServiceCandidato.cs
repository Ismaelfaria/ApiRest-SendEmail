﻿using AutoMapper;
using FluentValidation;
using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Models;
using ProcessoSeletivo_API.Models.Validations;
using ProcessoSeletivo_API.Repository;

namespace ProcessoSeletivo_API.Service
{
    public class ServiceCandidato : IServiceCandidato
    {
        private readonly IRepositoryCandidato _repositoryCandidato;
        private readonly IMapper _mapper;
        private readonly IValidator<CandidatoInputModel> _inputValidator;

        public ServiceCandidato(IRepositoryCandidato repositoryCandidato, IMapper mapper, IValidator<CandidatoInputModel> inputValidator)
        {
            _repositoryCandidato = repositoryCandidato;
            _mapper = mapper;
            _inputValidator = inputValidator;
        }

        public IEnumerable<Candidato> FindAll()
        {
            try
            {
                return _repositoryCandidato.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao visualizar todos os paciente.(Service)", ex);
            }
        }

        public Candidato FindById(Guid id)
        {
            try
            {
                return _repositoryCandidato.FindById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao visualizar o paciente.(Service)", ex);
            }
        }

        public Candidato Create(CandidatoInputModel candidato)
        {
            try
            {
                var validatorResult = _inputValidator.Validate(candidato);
                if (!validatorResult.IsValid)
                {
                    throw new ValidationException("Erro de validação ao criar o paciente", validatorResult.Errors);
                }


                var input = _mapper.Map<Candidato>(candidato);
                input.Id = Guid.NewGuid();

                _repositoryCandidato.Save(input);

                return input;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar os paciente.(Service)", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _repositoryCandidato.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao deletar o paciente.(Service)", ex);
            }
        }

        public void Update(Guid id, CandidatoInputModel candidato)
        {
            try
            {
                var input = _mapper.Map<Candidato>(candidato);
                _repositoryCandidato.Update(id, input);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o paciente.(Service)", ex);
            }
        }

        public Candidato FindByEmail(string email)
        {
            try
            {
                return _repositoryCandidato.FindByEmail(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao visualizar o paciente.(Service)", ex);
            }
        }
    }
}
