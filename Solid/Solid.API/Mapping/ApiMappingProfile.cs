using AutoMapper;
using Solid.API.models;
using Solid.Core.Entities;

namespace Solid.API.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<GuidePostModel, Guide>();
            CreateMap<StudentPostModel, Student>();
            CreateMap<TrainingPostModel, Training>();

        }
    }
}
