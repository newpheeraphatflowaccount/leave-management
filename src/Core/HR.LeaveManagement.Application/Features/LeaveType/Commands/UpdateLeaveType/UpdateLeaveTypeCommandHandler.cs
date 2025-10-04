using System;
using AutoMapper;
using HR.LeaveManagement.Application.Contacts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
  private readonly IMapper _mapper;
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
  {
    // Validate incoming data
    var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (validationResult.Errors.Any())
      throw new BadRequestException("UpdateLeaveTypeCommand: Invalid Leave Type", validationResult);

    // Convert to domain entity object
    var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

    // Update in database
    await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

    // Return success
    return Unit.Value;
  }
}
