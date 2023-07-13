using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Domain;
using LeaveManagement.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistance.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {

        public LeaveRequestRepository(LmDatabaseContext context) : base(context)
        {

        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                                       .Include(q=> q.LeaveType)
                                       .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
                                     .Where(q=> q.RequestingEmployeeId == userId)
                                     .Include(q => q.LeaveType)
                                     .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                                     .Include(q=> q.LeaveType)
                                     .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }
    }
}
