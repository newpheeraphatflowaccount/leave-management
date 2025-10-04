using System;

namespace HR.LeaveManagement.Application.Exceptions;

public class NotFoundException : Exception
{
  public NotFoundException(string name, object key) : base($"{name} with key {key} was not found.")
  {
  }
}
