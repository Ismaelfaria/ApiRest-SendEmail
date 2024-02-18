using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Models;

namespace ProcessoSeletivo_API.Repository
{
    public interface IRepositoryCandidato
    {
        IEnumerable<Candidato> FindAll();
        Candidato FindById(Guid id);
        Candidato FindByEmail(EmailInputModel email);
        Candidato Save(Candidato candidato);
        void Update(Guid id, Candidato candidato);
        void Delete(Guid id);
    }
}
