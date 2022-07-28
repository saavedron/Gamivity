using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GameModeRepository : IGameModeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GameModeRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public Task<IEnumerable<BaseQuestion>> GetQuestionsAllAsync()
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<BaseQuestion>> GetQuestionsByClassAsync(string generalClassName)
        {
            var generalClass = await _context.GeneralClasses.FirstOrDefaultAsync(g => g.GeneralClassName == generalClassName);
            var questions = await _context.BaseQuestions.Include(a => a.Answers).
                Where(b => b.GeneralClass == generalClass).
                OrderBy(b => Guid.NewGuid()).Take(10).ToListAsync();
            return questions;

        }

        public async Task<IEnumerable<BaseQuestion>> GetQuestionsByClassLevelAsync(int classLevel)
        {
            var questions = await _context.BaseQuestions.Include(a => a.Answers).
                Where(b => b.GeneralClass.ClassLevel == classLevel).
                OrderBy(b => Guid.NewGuid()).Take(10).ToListAsync();
            return questions;
        }

    }
}