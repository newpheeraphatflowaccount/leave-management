using System;
using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandValidator : AbstractValidator<DeleteLeaveTypeCommand>
{
  public DeleteLeaveTypeCommandValidator()
  {
    RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.");
  }
}
