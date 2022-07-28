using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class BaseQuestionRepository : IBaseQuestionRepository
    {
        private readonly DataContext _context;
        public BaseQuestionRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<bool> AddAndSaveBaseQuesiton(BaseQuestion baseQuestion)
        {
            _context.BaseQuestions.Add(baseQuestion);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}