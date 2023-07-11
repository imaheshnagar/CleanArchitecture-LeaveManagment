using FluentValidation;
using LeaveManagement.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator:AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(r=>r.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70);

            RuleFor(r => r.DefaultDays)
                .GreaterThan(1).WithMessage("{PropertyName} can must greater than 1 ")
                .LessThan(100).WithMessage("{PropertyName} can not exceed 100");

            RuleFor(r => r)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave Type already exist");

            this._leaveTypeRepository = leaveTypeRepository;
        }

 

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
