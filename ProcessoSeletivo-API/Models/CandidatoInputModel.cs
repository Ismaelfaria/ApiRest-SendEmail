namespace ProcessoSeletivo_API.Models
{
    public class CandidatoInputModel
    {
        public string Name { get; set; }
        public int CPF { get; set; }
        public List<string> Skils { get; set; }
        public string Email { get; set; }
    }
}
