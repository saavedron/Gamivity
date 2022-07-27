using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ITestRepository
    {
        Task<bool> SaveAllAsync();
        void AddTest(Test test);

        Task<IEnumerable<BaseQuestionDto>> GetBaseQuestions(string generalClassName);

        // Task<Test> GetTest();
    }
}