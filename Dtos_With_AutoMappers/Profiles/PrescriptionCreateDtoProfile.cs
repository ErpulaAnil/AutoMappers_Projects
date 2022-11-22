using AutoMapper;
using Dtos_With_AutoMappers.Dtos;
using Dtos_With_AutoMappers.Models;

namespace Dtos_With_AutoMappers.Profiles
{
    public class PrescriptionCreateDtoProfile:Profile
    {
        public PrescriptionCreateDtoProfile()
        {
            //Source => Destination
            CreateMap<PrescriptionCreateDto, Prescription>();
        }
    }
}
