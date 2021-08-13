using Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PaginationService : IPaginationService
    {
        private  readonly int maxCount = 50;

        public int ValidateCount(int count)
        {
            return count < 0 || count > maxCount ? maxCount : count;
        }

        public int ValidateSkip(int skip)
        {
            return skip < 0 ? 0 : skip;
        }
    }
}
