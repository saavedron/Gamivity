using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly IClassesRepository _classesRepository;
        private readonly ITestRepository _testRepository;
        private readonly IGeneralClassRepository _generalClassRepository;
        public TestController(IClassesRepository classesRepository, ITestRepository testRepository, IGeneralClassRepository generalClassRepository)
        {
            _generalClassRepository = generalClassRepository;
            _testRepository = testRepository;
            _classesRepository = classesRepository;

        }

        [HttpPost("addTest")]
        public async Task<ActionResult> AddTestToClass(AddTestDto testPayload)
        {

            var _class = await _classesRepository.GetClassByName(testPayload.ClassName);

            var generalClass = await _generalClassRepository.GetGeneralClassByIdAsync(_class.GeneralClassId);

            List<BaseQuestion> baseQuestions = new List<BaseQuestion>();

            foreach (var t in testPayload.Test.TestQuestions)
            {
                //if the question doesn't exists in the db already
                if (t.Id == 0)
                    baseQuestions.Add(t.BaseQuestion);
            }
            generalClass.BaseQuestions = baseQuestions;

            await _classesRepository.UpdateAndSaveGeneralClass(generalClass);


            var test = new Test
            {
                TestQuestions = testPayload.Test.TestQuestions
            };

            _testRepository.AddTest(test);

            await _testRepository.SaveAllAsync();

            var classTests = new ClassTest
            {
                ClassId = _class.Id,
                TestId = test.Id
            };

            _class.ClassTests.Add(classTests);

            if (await _classesRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add test to class");

        }

        [HttpGet("getBaseQuestions/{generalClassName}")]
        public async Task<ActionResult<IEnumerable<BaseQuestionDto>>> GetQuestions(string generalClassName)
        {
            return Ok(await _testRepository.GetBaseQuestions(generalClassName));

        }






    }
}