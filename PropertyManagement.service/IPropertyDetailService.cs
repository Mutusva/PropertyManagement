using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.service
{
  public interface IPropertyDetailService
  {
    Task<IEnumerable<PropertyDetail>> getAllPropertyDetails();

    Task<PropertyDetail> getPropertyDetails(int propertDetailId);

    Task<IEnumerable<PropertyDetail>> searchPropertyDetails(PropertySearchModel searchModel);
  }
}
