using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public record class GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
