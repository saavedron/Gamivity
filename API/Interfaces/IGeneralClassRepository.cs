using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IGeneralClassRepository
    {
        Task<GeneralClass> GetGeneralClassByIdAsync(int generalClassId);
        Task<GeneralClass> GetByNameAsync(string generalClassName);

    }
}