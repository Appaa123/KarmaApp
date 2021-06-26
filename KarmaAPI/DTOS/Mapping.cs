using AutoMapper;
using KarmaAPI.Models;

namespace KarmaAPI.DTOS
{
    public class Mapping : Profile
    {
        public Mapping() {

            CreateMap<Task, TaskDTO>();

        }
    }
}