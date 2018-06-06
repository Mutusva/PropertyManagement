using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.service
{
  public interface IOwnerHistoryService
  {
    Task<IEnumerable<OwnerHistory>> getOwnerHistory(int propertyDetailId);
  }
}
