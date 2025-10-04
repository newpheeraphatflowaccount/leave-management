using System;
using AutoMapper;
using HR.LeaveManagement.Application.Contacts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
  {
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
  {
    // Retrieve the leave type to delete
    var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

    // Verify that record exists
    if (leaveTypeToDelete == null)
      throw new NotFoundException(nameof(LeaveType), request.Id);

    // Delete from database
    await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

    // Return success
    return Unit.Value;
  }
}
