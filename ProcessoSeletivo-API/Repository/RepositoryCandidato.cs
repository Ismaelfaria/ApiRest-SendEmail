using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Persistence.Context;
using ProcessoSeletivo_API.Service;

namespace ProcessoSeletivo_API.Repository
{
    public class RepositoryCandidato : IRepositoryCandidato
    {
        private readonly ContextAPI _context;
        private readonly IServiceEmail _mailService;

        public RepositoryCandidato(ContextAPI context, IServiceEmail mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public IEnumerable<Candidato> FindAll()
        {
            return _context.Candidato
           .Include(c => c.Email)
           .Where(c => !c.IsDeleted)
           .ToList();
        }

        public Candidato FindById(Guid id)
        {
            return _context.Candidato
                .Include(c => c.Email)
                .SingleOrDefault(c => c.Id == id);
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
            var register = _context.Candidato
                .Include(c => c.Email)
                .SingleOrDefault(c => c.Id == id);

            if (register == null)
            {
                Console.WriteLine($"Candidato com o ID {id} não encontrado.");
                return;
            }

            if (register.Email != null)
            {
                register.Deleted();
                _context.SaveChanges();

                _mailService.SendEmail(register.Email.Email, "EMPRESA-ISMAEL", "Seu cadastro foi deletado");
            }
            else
            {
                Console.WriteLine($"O e-mail do candidato com o ID {id} é nulo.");
            }

        }
    }
}
