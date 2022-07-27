using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TestRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void AddTest(Test test)
        {
            _context.Tests.Add(test);
        }

        public async Task<IEnumerable<BaseQuestionDto>> GetBaseQuestions(string generalClassName)
        {
            var generalClass = await _context.GeneralClasses.SingleOrDefaultAsync(g => g.GeneralClassName == generalClassName);
            return await _context.BaseQuestions.Where(b => b.GeneralClassId == generalClass.Id)
                .ProjectTo<BaseQuestionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}