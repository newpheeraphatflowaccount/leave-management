using System;
using AutoMapper;
using HR.LeaveManagement.Application.Contacts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
  private readonly IMapper _mapper;
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
  {
    // Query the database
    var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

    // Verify that record exists
    if (leaveType == null)
      throw new NotFoundException(nameof(LeaveType), request.Id);

    // Convert to dto
    var leaveTypeDto = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

    // Return dto
    return leaveTypeDto;
  }
}
