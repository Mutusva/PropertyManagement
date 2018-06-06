using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Repository.Interfaces
{
  public interface IOwnerHistoryRepository
  {
    Task<IEnumerable<OwnerHistory>> getOwnerHistory(int propertyDetailId);
  }
}
