using AutoMapper;
using ProcessoSeletivo_API.Entity;

namespace ProcessoSeletivo_API.Models.Profil
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<EmailInputModel, EmailEntity>();
        }
    }
}
