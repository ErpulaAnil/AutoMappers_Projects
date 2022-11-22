using AutoMapper;
using Dtos_With_AutoMappers.Dtos;
using Dtos_With_AutoMappers.Models;

namespace Dtos_With_AutoMappers.Profiles
{
    public class PrescriptionReadDtoProfile:Profile
    {
        public PrescriptionReadDtoProfile()
        {
            // Source -> Destination
            CreateMap<Prescription, PrescriptionReadDto>();
        }
    }
}
