using System.IO;
using AutoMapper;
using MiniProjet_BDA.Dto;
using MiniProjet_BDA.Models;
namespace MiniProjet_BDA.Extentions
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() 
        {
            CreateMap <User,UserDto>().ReverseMap();
            CreateMap<DefenseCreateDto, Defense>();
            CreateMap<Defense, DefenseDto>();
            CreateMap<DefenseDto, Defense>();
            CreateMap <Student,StudentDto>().ReverseMap();
            CreateMap <Professor,ProfessorDto>().ReverseMap();
            CreateMap <Room,RoomDto>().ReverseMap();
            CreateMap <Jury, JuryDto>().ReverseMap();
            CreateMap <Team, TeamDto>().ReverseMap();         
            CreateMap<StudentEvaluation,StudentEvaluationDto>().ReverseMap();   
            CreateMap <Project, ProjectDto>().ReverseMap();
        }

    }
   
}
