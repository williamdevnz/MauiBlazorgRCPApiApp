using AutoMapper;
using DataView2.Core.Models;
using MauiBlazorgRCPApiApp.Data;

namespace MauiBlazorgRCPApiApp.Models
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaDb>();
            CreateMap<PersonaDb, Persona>();
        }
    }
}
