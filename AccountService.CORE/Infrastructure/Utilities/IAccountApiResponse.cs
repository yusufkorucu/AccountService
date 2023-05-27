using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Domain.Infrastructure.Utilities
{
    public interface IAccountApiResponse
    {
        bool IsSuccess { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}
