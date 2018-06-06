using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.Model.Models;
using PropertyManagement.Repository.Interfaces;

namespace PropertyManagement.service
{
  public class PropertyDetailService : IPropertyDetailService
  {
    private readonly IPropertyDetailRepository _propertyDetailRepository;

    public PropertyDetailService(IPropertyDetailRepository propertyDetailRepository)
    {
      _propertyDetailRepository = propertyDetailRepository;
    }

    public async Task<IEnumerable<PropertyDetail>> getAllPropertyDetails()
    {
      return await _propertyDetailRepository.getAllPropertyDetails();
    }

    public async Task<PropertyDetail> getPropertyDetails(int propertDetailId)
    {
     return await _propertyDetailRepository.getPropertyDetails(propertDetailId);
    }

    public async Task<IEnumerable<PropertyDetail>> searchPropertyDetails(PropertySearchModel searchModel)
    {
      return await _propertyDetailRepository.searchPropertyDetails(searchModel);
    }
  }
}
