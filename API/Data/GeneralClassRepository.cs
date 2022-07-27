using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GeneralClassRepository : IGeneralClassRepository
    {
        private readonly DataContext _context;
        public GeneralClassRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<GeneralClass> GetGeneralClassByIdAsync(int generalClassId)
        {
            return await _context.GeneralClasses.FirstOrDefaultAsync(g => g.Id == generalClassId);
        }
    }
}