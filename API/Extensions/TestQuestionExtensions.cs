using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Extensions
{
    public static class TestQuestionExtensions
    {
        public static bool IsSpecial(this TestQuestion testQuestion)
        {
            Random rd = new Random();
            return rd.NextSingle() < 0.3f;
        }
    }
}