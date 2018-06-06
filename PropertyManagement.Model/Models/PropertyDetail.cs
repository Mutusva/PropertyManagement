using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PropertyManagement.Model.Models
{
  public class PropertyDetail
  {
    [Key]
    public int Id { get; set; }
    public decimal LandSize { get; set; }
    public decimal NumOfBedrooms { get; set; }
    public decimal NumOfbathrooms { get; set; }
    public int NumOfKitchens { get; set; }
    public int NumOfReceptionRooms { get; set; }
    public int NumOfGarages { get; set; }
    public int NumOfParkingSpots { get; set; }
    public string PropertyAddress { get; set; }
    public string PropertyDesc { get; set; }

    //[ForeignKey("PropertyDetailId")]
    public ICollection<OwnerHistory> OwnerHistory { get; set; }
    //[ForeignKey("PropertyDetailId")]
    public ICollection<PropertyImage> PropertyImage { get; set; }
  }
}
