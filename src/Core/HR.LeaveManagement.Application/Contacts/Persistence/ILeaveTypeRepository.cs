using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contacts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
  Task<bool> IsLeaveTypeUnique(string name);
}
