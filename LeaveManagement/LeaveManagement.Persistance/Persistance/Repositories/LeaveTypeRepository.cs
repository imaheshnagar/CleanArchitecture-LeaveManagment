using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Domain;
using LeaveManagement.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistance.Persistance.Repositories
{
    public class LeaveTypeRepository :GenericRepository<LeaveType>,ILeaveTypeRepository
    {

        public LeaveTypeRepository(LmDatabaseContext context):base(context)
        {
            
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return ! await _context.LeaveTypes.AnyAsync(q => q.Name == name);
        }
    }
}
