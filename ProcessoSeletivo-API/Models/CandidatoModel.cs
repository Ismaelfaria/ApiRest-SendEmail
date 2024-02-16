using ProcessoSeletivo_API.Entity;

namespace ProcessoSeletivo_API.Models
{
    public abstract class CandidatoModel
    {
        public string Name { get; set; }
        public int CPF { get; set; }
        public List<string> Skils { get; set; }
        public EmailInputModel Email { get; set; }
    }
}
