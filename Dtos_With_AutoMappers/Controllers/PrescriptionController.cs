using AutoMapper;
using Dtos_With_AutoMappers.Dtos;
using Dtos_With_AutoMappers.Models;
using Dtos_With_AutoMappers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dtos_With_AutoMappers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;
        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }
        // GET: api/<PrescrptionController>
        [HttpGet]
        public ActionResult<IEnumerable<PrescriptionReadDto>> Get()
        {
            var prescriptions = _prescriptionRepository.GetAll();

            var prescriptionDto = _mapper.Map<IEnumerable<PrescriptionReadDto>>(prescriptions);

            if (prescriptions == null)
            {
                return NotFound();
            }
            return Ok(prescriptionDto);

        }

        [HttpGet("{id}", Name = "GetPrescriptionById")]
        public ActionResult<PrescriptionReadDto> GetPrescriptionById(int id)
        {
            var prescription = _prescriptionRepository.Get(id);
            if (prescription == null)
            {
                return NotFound(id);
            }
            return (_mapper.Map<PrescriptionReadDto>(prescription));
        }

        [HttpPost]
        public ActionResult<PrescriptionReadDto> CreatePrescription(
            PrescriptionCreateDto prescriptionCreateDto)
        {

            //Mapping to Persist to Data
            var prescriptionModel = _mapper.Map<Prescription>(prescriptionCreateDto);

            _prescriptionRepository.Create(prescriptionModel);
            _prescriptionRepository.SaveChanges();

            //Mapp from Prescription to its Dtod
            var prescriptionReadDto = _mapper.Map<PrescriptionReadDto>(prescriptionModel);

            return CreatedAtRoute(nameof(GetPrescriptionById),
                new { Id = prescriptionReadDto.Id }, prescriptionReadDto);
        }
    }
}
