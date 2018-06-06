using PropertyManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.UI.Models
{
  public class PropertyModel
  {
    public List<PropertyDetailViewModel> PropertyDetails { get; set; }

    public PropertySearchModel propertySearch { get; set; }
  }
}
