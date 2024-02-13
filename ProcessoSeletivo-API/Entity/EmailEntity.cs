namespace ProcessoSeletivo_API.Entity
{
    public class EmailEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Guid CandidatoId { get; set; }
    }
}
