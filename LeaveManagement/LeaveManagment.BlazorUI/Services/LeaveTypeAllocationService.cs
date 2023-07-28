using Blazored.LocalStorage;
using LeaveManagement.BlazorUI.Contracts;
using LeaveManagement.BlazorUI.Services.Base;

namespace LeaveManagement.BlazorUI.Services
{
    public class LeaveTypeAllocationService : BaseHttpService, ILeaveTypeAllocationService
    {
        public LeaveTypeAllocationService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
