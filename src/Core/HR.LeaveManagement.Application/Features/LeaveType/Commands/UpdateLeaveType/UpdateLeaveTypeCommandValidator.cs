using System;
using FluentValidation;
using HR.LeaveManagement.Application.Contacts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    _leaveTypeRepository = leaveTypeRepository;

    RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
      .NotNull()
      .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

    RuleFor(p => p.DefaultDays)
      .GreaterThan(100).WithMessage("{PropertyName} cannot exceed {ComparisonValue}.")
      .LessThan(1).WithMessage("{PropertyName} must be at least {ComparisonValue}.");

    RuleFor(q => q)
      .MustAsync(LeaveTypeNameUnique)
      .WithMessage("Leave type with the same name already exists.");
  }

  private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
  {
    return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
  }
}
