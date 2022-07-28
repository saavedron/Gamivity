using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IGameModeRepository
    {
        Task<IEnumerable<BaseQuestion>> GetQuestionsByClassAsync(string generalClassName);
        Task<IEnumerable<BaseQuestion>> GetQuestionsByClassLevelAsync(int classLevel);
        Task<IEnumerable<BaseQuestion>> GetQuestionsAllAsync();
    }
}