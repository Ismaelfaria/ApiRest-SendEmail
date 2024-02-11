using ProcessoSeletivo_API.Entity;

namespace ProcessoSeletivo_API.Repository
{
    public interface IRepositoryCandidato
    {
        IEnumerable<Candidato> FindAll();
        Candidato FindById(Guid id);
        Candidato Save(Candidato candidato);
        void Update(Guid id, Candidato candidato);
        void Delete(Guid id);
    }
}
