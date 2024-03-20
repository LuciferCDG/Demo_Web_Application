using AutoMapper;
using Demo_Web_Application.Models;
using DomainModel = Demo_Web_Application.Core.Model;

namespace Demo_Web_Application
{
    public class AutomapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<StudentDto, DomainModel.Student>();
            Mapper.CreateMap<DomainModel.Student, StudentDto>();
        }
    }
}
