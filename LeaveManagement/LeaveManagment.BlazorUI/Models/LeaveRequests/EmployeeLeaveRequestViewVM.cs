﻿using  LeaveManagement.BlazorUI.Models.LeaveAllocations;

namespace  LeaveManagement.BlazorUI.Models.LeaveRequests
{
    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; } = new List<LeaveAllocationVM>();
        public List<LeaveRequestVM> LeaveRequests { get; set; } = new List<LeaveRequestVM>();
    }
}
