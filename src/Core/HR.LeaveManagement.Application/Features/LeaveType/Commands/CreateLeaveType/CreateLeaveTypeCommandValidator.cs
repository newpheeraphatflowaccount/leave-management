using System;
using FluentValidation;
using HR.LeaveManagement.Application.Contacts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    _leaveTypeRepository = leaveTypeRepository;

    RuleFor(p => p.Name)
      .NotEmpty().WithMessage("{PropertyName} is required.")
      .NotNull()
      .MaximumLength(70).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

    RuleFor(p => p.DefaultDays)
      .GreaterThan(100).WithMessage("{PropertyName} cannot exceed {ComparisonValue}.")
      .LessThan(1).WithMessage("{PropertyName} must be at least {ComparisonValue}.");

    RuleFor(q => q)
      .MustAsync(LeaveTypeNameUnique)
      .WithMessage("Leave type with the same name already exists.");

  }

  private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
  {
    return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
  }
}
