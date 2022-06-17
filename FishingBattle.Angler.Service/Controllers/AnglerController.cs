using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FishingBattle.Anglers.Service.DTOs;
using FishingBattle.Anglers.Service.Interfaces;
using FishingBattle.Anglers.Service.Models;

namespace FishingBattle.Anglers.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnglerController : ControllerBase
    {
        private readonly IAnglerRepository _anglerRepository;
        private readonly IMapper _mapper;

        public AnglerController(IAnglerRepository anglerRepository, IMapper mapper)
        {
            _anglerRepository = anglerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public async Task<ActionResult<AnglerDto>> Get(int id)
        {
            var angler = await _anglerRepository.GetAngler(id);
            if (angler is null) return NotFound();

            return _mapper.Map<AnglerDto>(angler);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<AnglerDto>>> GetAll()
        {
            var anglers = await _anglerRepository.GetAllAnglers();

            return _mapper.Map<List<AnglerDto>>(anglers);
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<Angler>> Create(AnglerDto anglerDto)
        { 
            if(anglerDto == null) return BadRequest();

            var anglerToCreate = _mapper.Map<Angler>(anglerDto);
            var createdAngler = await _anglerRepository.CreateAngler(anglerToCreate);

            return CreatedAtAction(nameof(Get), new { id = createdAngler.Id }, createdAngler);
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult<AnglerDto>> Update(int id, Angler angler)
        {
            if (angler.Id != id) return BadRequest();

            var isUpdated = await _anglerRepository.UpdateAngler(angler);
            if (!isUpdated) return NotFound("No such Angler to update.");

            return CreatedAtAction(nameof(Get), id, angler);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await _anglerRepository.DeleteAngler(id);
            if (!isDeleted) return NotFound("No such Angler to delete.");

            return NoContent();
        }
    }
}
