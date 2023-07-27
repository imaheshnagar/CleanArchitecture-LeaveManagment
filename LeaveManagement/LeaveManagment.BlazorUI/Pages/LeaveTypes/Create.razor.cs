using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using LeaveManagnent.BlazorUI;

using System.Net;
using System.Numerics;
using LeaveManagment.BlazorUI.Contracts;
using LeaveManagment.BlazorUI.Models.LeaveTypes;
using LeaveManagment.BlazorUI.Shared;
//using Blazored.Toast.Services;

namespace LeaveManagnent.BlazorUI.Pages.LeaveTypes
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        [Inject]
        ILeaveTypeService _client { get; set; }
        //[Inject]
        //IToastService toastService { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();
        async Task CreateLeaveType()
        {
            var response = await _client.CreateLeaveType(leaveType);
            if(response.Success)
            {
                //toastService.ShowSuccess("Leave Type created Successfully");
                //toastService.ShowToast(ToastLevel.Info, "Test");
                _navManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}