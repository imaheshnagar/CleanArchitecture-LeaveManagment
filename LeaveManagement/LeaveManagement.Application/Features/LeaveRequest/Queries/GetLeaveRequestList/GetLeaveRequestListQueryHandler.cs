using AutoMapper;
//using LeaveManagement.Application.Contracts.Identity;
using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
      //  private readonly IUserService _userService;

        public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper//,IUserService userService
                            )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
           // this._userService = userService;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
        {

            var leaveRequests = new List<Domain.LeaveRequest>();
            var requests = new List<LeaveRequestListDto>();

            // Check if it is logged in employee
             leaveRequests = await _leaveRequestRepository.GetAllLeaveRequestsWithDetails();
             requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);

             return requests;
        }
    }
}
