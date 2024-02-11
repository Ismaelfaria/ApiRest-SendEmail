using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Repository;

namespace ProcessoSeletivo_API.Service
{
    public class ServiceCandidato : IServiceCandidato
    {
        private readonly IRepositoryCandidato _repositoryCandidato;
        public ServiceCandidato(IRepositoryCandidato repositoryCandidato)
        {
            _repositoryCandidato = repositoryCandidato;
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
        public Candidato Create(Candidato candidato)
        {
            try
            {
                return _repositoryCandidato.Save(candidato);
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

        

        public void Update(Guid id, Candidato candidato)
        {
            try
            {
                _repositoryCandidato.Update(id, candidato);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o paciente.(Service)", ex);
            }
        }
    }
}
