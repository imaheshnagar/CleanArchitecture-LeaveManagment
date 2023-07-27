using LeaveManagment.BlazorUI.Contracts;

namespace LeaveManagment.BlazorUI.Services.Base
{
    public class LeaveTypeRequestService : BaseHttpService, ILeaveTypeRequestService
    {
        public LeaveTypeRequestService(IClient client) : base(client)
        {
        }
    }
}
