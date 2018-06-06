using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PropertyManagement.Model.Models
{
  public class PropertySearchModel
  {
    [DisplayName("Owner Name")]
    public string OwnerName { get; set; }

    [DisplayName("Address")]
    public string Address { get; set; }

    [DisplayName("Number of Bedrooms")]
    public decimal? NumOfBedrooms { get; set; }

    [DisplayName("Number of Bathrooms")]
    public int? NumOfBathrooms { get; set; }
  }
}
