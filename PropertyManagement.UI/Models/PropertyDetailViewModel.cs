using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.UI.Models
{
  public class PropertyDetailViewModel
  {
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
    public string Image { get; set; }
  }
}
