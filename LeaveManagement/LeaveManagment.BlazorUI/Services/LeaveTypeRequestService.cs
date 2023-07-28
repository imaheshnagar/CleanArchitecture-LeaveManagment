using Blazored.LocalStorage;
using LeaveManagement.BlazorUI.Contracts;
using LeaveManagement.BlazorUI.Services.Base;

namespace LeaveManagement.BlazorUI.Services
{
    public class LeaveTypeRequestService : BaseHttpService, ILeaveTypeRequestService
    {
        public LeaveTypeRequestService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
