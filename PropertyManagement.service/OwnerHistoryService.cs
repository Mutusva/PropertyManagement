using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.Model.Models;
using PropertyManagement.Repository.Concretes;
using PropertyManagement.Repository.Interfaces;

namespace PropertyManagement.service
{
  public class OwnerHistoryService : IOwnerHistoryService
  {
    private readonly IOwnerHistoryRepository _ownerHistoryRepository;

    public OwnerHistoryService(IOwnerHistoryRepository ownerHistoryRepository)
    {
      _ownerHistoryRepository = ownerHistoryRepository;
    }

    public async Task<IEnumerable<OwnerHistory>> getOwnerHistory(int propertyDetailId)
    {
      return await _ownerHistoryRepository.getOwnerHistory(propertyDetailId);
    }
  }
}
