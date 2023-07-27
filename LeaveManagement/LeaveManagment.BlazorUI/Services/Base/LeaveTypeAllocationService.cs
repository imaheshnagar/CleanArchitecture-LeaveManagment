using LeaveManagment.BlazorUI.Contracts;

namespace LeaveManagment.BlazorUI.Services.Base
{
    public class LeaveTypeAllocationService : BaseHttpService, ILeaveTypeAllocationService
    {
        public LeaveTypeAllocationService(IClient client) : base(client)
        {
        }
    }
}
