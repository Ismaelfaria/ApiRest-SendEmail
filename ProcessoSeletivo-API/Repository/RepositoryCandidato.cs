using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Persistence.Context;

namespace ProcessoSeletivo_API.Repository
{
    public class RepositoryCandidato : IRepositoryCandidato
    {
        private readonly ContextAPI _context;

        public RepositoryCandidato(ContextAPI context) {

            _context = context;
        }

        public IEnumerable<Candidato> FindAll()
        {
           return _context.Candidato.Where(c => !c.IsDeleted).ToList();
        }

        public Candidato FindById(Guid id)
        {
            return _context.Candidato.SingleOrDefault(c => c.Id == id);
        }

        public Candidato Save(Candidato candidato)
        {
            _context.Candidato.Add(candidato);
            _context.SaveChanges();
            return candidato;
        }

        public void Update(Guid id, Candidato input)
        {
            var register = _context.Candidato.SingleOrDefault(c => c.Id == id);

            register.Update(input.Name, input.CPF, input.Skils);

            _context.SaveChanges();
        } 

        public void Delete(Guid id)
        {
            var register = _context.Candidato.SingleOrDefault(c => c.Id == id);
            register.Deleted();
            _context.SaveChanges();
        }
    }
}
