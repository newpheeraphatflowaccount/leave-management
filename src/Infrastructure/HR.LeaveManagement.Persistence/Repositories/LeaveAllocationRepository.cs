using HR.LeaveManagement.Application.Contacts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
  public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
  {
  }
}
