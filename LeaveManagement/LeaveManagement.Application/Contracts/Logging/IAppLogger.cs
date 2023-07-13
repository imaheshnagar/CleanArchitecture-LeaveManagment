using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Contracts.Logging
{
    public interface IAppLogger<T>
    {

        void LogInformation(string message,params Object[] args);

        void LogWarning(string message, params Object[] args);

    }
}
