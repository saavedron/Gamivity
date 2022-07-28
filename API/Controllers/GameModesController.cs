using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GameModesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGameModeRepository _gameModeRepository;
        public GameModesController(IGameModeRepository gameModeRepository, IMapper mapper)
        {
            _gameModeRepository = gameModeRepository;
            _mapper = mapper;

        }

        [HttpGet("questionsByClass/{generalClassName}")]
        public async Task<ActionResult<IEnumerable<BaseQuestionDto>>> GetQuestionsByClass(string generalClassName)
        {
            var baseQuestions = await _gameModeRepository.GetQuestionsByClassAsync(generalClassName);

            var baseQuestionsToReturn = _mapper.Map<IEnumerable<BaseQuestionDto>>(baseQuestions);
            return Ok(baseQuestionsToReturn);
        }


        [HttpGet("questionsByClassLevel/{classLevel}")]
        public async Task<ActionResult<IEnumerable<BaseQuestionDto>>> GetQuestionsByClassLevel(int classLevel)
        {
            var baseQuestions = await _gameModeRepository.GetQuestionsByClassLevelAsync(classLevel);

            var baseQuestionsToReturn = _mapper.Map<IEnumerable<BaseQuestionDto>>(baseQuestions);
            return Ok(baseQuestionsToReturn);
        }

    }
}