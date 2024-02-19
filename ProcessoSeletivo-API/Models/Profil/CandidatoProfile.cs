using AutoMapper;
using ProcessoSeletivo_API.Entity;
using ProcessoSeletivo_API.Models;

public class CandidatoProfile : Profile
{
    public CandidatoProfile()
    {
        CreateMap<CandidatoInputModel, Candidato>();
    }
}

