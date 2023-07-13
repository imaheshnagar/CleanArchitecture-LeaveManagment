using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

        Task<List<LeaveRequest>> GetAllLeaveRequestsWithDetails();

        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
    }
}
