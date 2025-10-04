using System;
using AutoMapper;
using HR.LeaveManagement.Application.Contacts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
  private readonly IMapper _mapper;
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
  {
    // Query the database
    var leaveTypes = await _leaveTypeRepository.GetAsync();

    // Convert to dto
    var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

    // Return list of dto
    return data;
  }
}
