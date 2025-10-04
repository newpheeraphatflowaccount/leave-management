using HR.LeaveManagement.Application.Contacts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
  public LeaveRequestRepository(HrDatabaseContext context) : base(context)
  {
  }
}
