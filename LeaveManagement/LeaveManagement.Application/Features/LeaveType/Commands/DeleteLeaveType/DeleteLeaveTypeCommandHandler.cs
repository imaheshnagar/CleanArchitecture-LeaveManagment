using AutoMapper;
using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler( ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public  async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming Data

            // get record to delete

            var LeaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (LeaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType),request.Id);
            }

           //delete from database

           await _leaveTypeRepository.DeleteAsync(LeaveTypeToDelete);

            // return record id
            return Unit.Value;
        }
    }
}
