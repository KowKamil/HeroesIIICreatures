using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Heroes_3_Creatures.Dtos;
using Heroes_3_Creatures.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Heroes_3_Creatures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatureController : ControllerBase
    {
        private readonly ILogger<CreatureController> _logger;
        private readonly ICreaturesRepo _creaturesRepo;
        private readonly IMapper _mapper;

        public CreatureController(ILogger<CreatureController> logger, ICreaturesRepo creaturesRepo, IMapper mapper)
        {
            _logger = logger;
            _creaturesRepo = creaturesRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CreatureReadDto>> Get(int? id, int? tier, string name, string fractionName)
        {
            var creatures = _creaturesRepo.Get(id, tier, name, fractionName);

            if (creatures != null)
            {
                return Ok(_mapper.Map<IEnumerable<CreatureReadDto>>(creatures)); //Automapper
                //return Ok(creatures.Select(c=>c.MapCreatureToDto())); //manual map
                //return Ok(creatures); //no mapping
            }
            else
                return NotFound();
        }

        /*[HttpGet]
        public ActionResult <IEnumerable<CreatureReadDto>> GetAll()
        {
            var creatures = _creaturesRepo.GetAllCreatures();

            if (creatures != null)
            {
                return Ok(_mapper.Map<IEnumerable<CreatureReadDto>>(creatures)); //Automapper
                //return Ok(creatures.Select(c=>c.MapCreatureToDto())); //manual map
                //return Ok(creatures); //no mapping
            }
            else 
                return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<CreatureReadDto> GetById(int id)
        {
            var creature = _creaturesRepo.GetCreatureById(id);

            if (creature != null)
                return Ok(_mapper.Map<CreatureReadDto>(creature)); //Automapper
                //return Ok(creature.MapCreatureToDto()); //manual map
                //return Ok(creature); //no mapping
            else
                return NotFound();
        }*/
    }
}
