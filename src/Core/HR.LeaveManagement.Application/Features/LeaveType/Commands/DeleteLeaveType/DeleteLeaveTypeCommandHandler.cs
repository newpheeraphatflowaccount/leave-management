using System;
using AutoMapper;
using HR.LeaveManagement.Application.Contacts.Persistence;
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

    // Delete from database
    await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

    // Return success
    return Unit.Value;
  }
}
