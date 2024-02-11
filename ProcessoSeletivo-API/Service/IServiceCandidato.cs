using ProcessoSeletivo_API.Entity;

namespace ProcessoSeletivo_API.Service
{
    public interface IServiceCandidato
    {
        IEnumerable<Candidato> FindAll();
        Candidato FindById(Guid id);
        Candidato Create(Candidato candidato);
        void Update(Guid id, Candidato candidato);
        void Delete(Guid id);
    }
}
