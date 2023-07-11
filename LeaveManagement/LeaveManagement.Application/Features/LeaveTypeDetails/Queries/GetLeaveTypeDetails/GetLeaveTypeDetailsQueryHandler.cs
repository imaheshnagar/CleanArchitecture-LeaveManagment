using AutoMapper;
using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveTypeDetails.Queries.GetLeaveTypeDetails
{
    internal class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }


        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            // query the database

            var leaveTypeDetail = _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeDetail == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }


            // mapper domain to dto

            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetail);

            //return list of dto obj
            return data;
        }
    }
}
