using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.Model.Models;
using PropertyManagement.Repository.Interfaces;

namespace PropertyManagement.service
{
  public class PropertyImageService : IPropertyImageService
  {
    private readonly IPropertyImageRepository _propertyImageRepository;

    public PropertyImageService(IPropertyImageRepository propertyImageRepository)
    {
      _propertyImageRepository = propertyImageRepository;
    }

    public async Task<IEnumerable<PropertyImage>> getPropertyImages(int propertyDetailId)
    {
      return await _propertyImageRepository.getPropertyImages(propertyDetailId);
    }
  }
}
