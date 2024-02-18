using AutoMapper;
using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Models;
using ProcessoSeletivo_API.Repository;

namespace ProcessoSeletivo_API.Service
{
    public class ServiceCandidato : IServiceCandidato
    {
        private readonly IRepositoryCandidato _repositoryCandidato;
        private readonly IMapper _mapper;
        public ServiceCandidato(IRepositoryCandidato repositoryCandidato, IMapper mapper)
        {
            _repositoryCandidato = repositoryCandidato;
            _mapper = mapper;

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
                var input = _mapper.Map<Candidato>(candidato);

                input.Id = Guid.NewGuid();
                input.Email.Id = Guid.NewGuid();

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

        public Candidato FindByEmail(EmailInputModel email)
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
