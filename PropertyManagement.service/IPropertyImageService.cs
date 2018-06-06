using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.service
{
  public interface IPropertyImageService
  {
    Task<IEnumerable<PropertyImage>> getPropertyImages(int propertyDetailId);
  }
}
