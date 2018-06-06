using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Repository.Interfaces
{
  public interface IPropertyImageRepository
  {
    Task<IEnumerable<PropertyImage>> getPropertyImages(int propertyDetailId);
  }
}
