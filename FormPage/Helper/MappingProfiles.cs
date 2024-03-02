using AutoMapper;
using FormPage.Dto;
using FormPage.Entity;

namespace FormPage.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<PersonInfo, PersonDto>();
            CreateMap<Courses, CoursesDto>();
            CreateMap<Experience, ExperienceDto>();
            CreateMap<PersonDto, PersonInfo>();
            CreateMap<CoursesDto, Courses>();
            CreateMap<ExperienceDto, Experience>();
        }
           
    }
}
