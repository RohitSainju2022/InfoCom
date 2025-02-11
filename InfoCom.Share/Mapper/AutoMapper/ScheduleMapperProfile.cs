using AutoMapper;
using InfoCom.Model;
using InfoCom.Ui.Models.Models;

namespace InfoCom.Share.Mapper.AutoMapper
{
    public class ScheduleMapperProfile : Profile
    {
        public ScheduleMapperProfile()
        {
            CreateMap<Schedule, ScheduleModel>().ReverseMap();
        }
    }
}
