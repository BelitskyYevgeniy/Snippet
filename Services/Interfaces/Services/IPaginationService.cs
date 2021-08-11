using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IPaginationService
    {
        int ValidateCount(int count);

        int ValidateSkip(int skip);
    }
}
