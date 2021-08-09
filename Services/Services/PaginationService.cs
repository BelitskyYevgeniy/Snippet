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
            if (count > maxCount)
            {
                return 50;
            }
            else if (count < 0)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }
    }
}
