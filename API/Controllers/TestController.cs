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
        private readonly IBaseQuestionRepository _baseQuestionRepository;
        public TestController(IClassesRepository classesRepository, ITestRepository testRepository, IGeneralClassRepository generalClassRepository, IBaseQuestionRepository baseQuestionRepository)
        {
            _baseQuestionRepository = baseQuestionRepository;
            _generalClassRepository = generalClassRepository;
            _testRepository = testRepository;
            _classesRepository = classesRepository;

        }


        [HttpPost("add")]
        public async Task<ActionResult> AddTest(AddTestDto testPayload)
        {
            var _class = await _classesRepository.GetClassByName(testPayload.ClassName);
            var generalClass = await _generalClassRepository.GetGeneralClassByIdAsync(_class.Id);

            List<TestQuestion> testQuestions = new List<TestQuestion>();
            foreach (var tq in testPayload.Test.TestQuestions)
            {
                var bq = tq.BaseQuestion;
                //if base question doesn't exist in the db already
                if (bq.Id == 0)
                {
                    bq.GeneralClass = generalClass;
                    testQuestions.Add(new TestQuestion
                    {
                        TimeToFinish = tq.TimeToFinish,
                        BaseQuestion = bq
                    });
                }
                else
                {
                    testQuestions.Add(new TestQuestion
                    {
                        TimeToFinish = tq.TimeToFinish,
                        BaseQuestionId = bq.Id
                    }
                    );
                }
            }

            var test = new Test
            {
                TestQuestions = testQuestions
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