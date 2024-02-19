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
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string name, int cpf, List<string> skils, string email)
        {
            Name = name;
            CPF = cpf;
            Skils = skils;
            Email = email;
        }
        public void Deleted()
        {
            IsDeleted = true;
        }
    }
}
