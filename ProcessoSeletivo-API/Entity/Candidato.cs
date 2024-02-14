namespace ProcessoSeletivo_API.Entity
{
    public class Candidato
    {
        public Candidato()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CPF { get; set; }
        public List<string> Skils { get; set; }
        public EmailEntity Email { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string name, int cpf, List<string> skils)
        {
            Name = name;
            CPF = cpf;
            Skils = skils;
        }
        public void Deleted()
        {
            IsDeleted = true;
        }
    }
}
