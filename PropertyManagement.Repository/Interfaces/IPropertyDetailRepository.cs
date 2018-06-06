using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Repository.Interfaces
{
  public interface IPropertyDetailRepository
  {
    Task<PropertyDetail> getPropertyDetails(int propertyDetailId);

    Task<IEnumerable<PropertyDetail>> searchPropertyDetails(PropertySearchModel searchModel);

    Task<IEnumerable<PropertyDetail>> getAllPropertyDetails();
  }
}
