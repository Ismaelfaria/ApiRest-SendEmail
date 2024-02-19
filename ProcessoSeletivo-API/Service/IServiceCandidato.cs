using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Models;

namespace ProcessoSeletivo_API.Service
{
    public interface IServiceCandidato
    {
        IEnumerable<Candidato> FindAll();
        Candidato FindById(Guid id);
        Candidato FindByEmail(string email);
        Candidato Create(CandidatoInputModel candidato);
        void Update(Guid id, CandidatoInputModel candidato);
        void Delete(Guid id);
    }
}
