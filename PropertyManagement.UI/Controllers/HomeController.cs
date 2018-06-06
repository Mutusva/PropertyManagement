using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PropertyManagement.Model.Models;
using PropertyManagement.service;
using PropertyManagement.UI.Models;

namespace PropertyManagement.UI.Controllers
{
  public class HomeController : Controller
  {
    private readonly IPropertyDetailService _propertyDetailService;

    public HomeController(IPropertyDetailService propertyDetailService)
    {
      _propertyDetailService = propertyDetailService;
    }
    public async Task<IActionResult> Index()
    {
      var results = await _propertyDetailService.getAllPropertyDetails();
      List<DataPoint> dataPoints = new List<DataPoint>();
      if (results != null)
      {
        dataPoints = getChatStats(results);
      }

      ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
      return View();
    }

    private static List<DataPoint> getChatStats(IEnumerable<Model.Models.PropertyDetail> results)
    {
      List<DataPoint> dataPoints;
      var percOneBed = results.Count(x => x.NumOfBedrooms == (decimal)1.00) != 0 ?
         ((results.Count(x => x.NumOfBedrooms == (decimal)1.00) * 100) / results.Count()) : 0;
      var percTwoBed = (results.Count(x => x.NumOfBedrooms > (decimal)1.00 && x.NumOfBedrooms <= (decimal)2.00)) != 0 ?
        ((results.Count(x => x.NumOfBedrooms > (decimal)1.00 && x.NumOfBedrooms <= (decimal)2.00) * 100) / results.Count()) : 0;
      var percThreeBed = (results.Count(x => x.NumOfBedrooms > (decimal)2.00 && x.NumOfBedrooms <= (decimal)3.00)) != 0 ?
        ((results.Count(x => x.NumOfBedrooms > (decimal)2.00 && x.NumOfBedrooms <= (decimal)3.00) * 100) / results.Count()) : 0;

      var percFourBed = results.Count(x => x.NumOfBedrooms > (decimal)3.00) != 0 ?
       ((results.Count(x => x.NumOfBedrooms > (decimal)3.00) * 100) / results.Count()) : 0;

      dataPoints = new List<DataPoint>{
        new DataPoint(1,percOneBed,"One bedrooms"),
        new DataPoint(1,percTwoBed,"Two bedrooms"),
        new DataPoint(1,percThreeBed,"Three bedrooms"),
        new DataPoint(1,percFourBed,"More Than Three bedrooms")
       };
      return dataPoints;
    }

    public async Task<IActionResult> Properties()
    {
      var results = await _propertyDetailService.getAllPropertyDetails();
      PropertyModel propertyModel = new PropertyModel();
      List<PropertyDetailViewModel> details = new List<PropertyDetailViewModel>();
      foreach (var item in results)
      {
        var propDetails = new PropertyDetailViewModel
        {
          Image = Convert.ToBase64String(item.PropertyImage?.FirstOrDefault().Image),
          Id = item.Id,
          NumOfbathrooms = item.NumOfbathrooms,
          NumOfBedrooms = item.NumOfBedrooms,
          LandSize = item.LandSize,
          NumOfGarages = item.NumOfGarages,
          NumOfKitchens = item.NumOfKitchens,
          NumOfParkingSpots = item.NumOfParkingSpots,
          NumOfReceptionRooms = item.NumOfReceptionRooms,
          PropertyAddress = item.PropertyAddress,
          PropertyDesc = item.PropertyDesc
        };
        details.Add(propDetails);
      }
      propertyModel.PropertyDetails = details;
      propertyModel.propertySearch = new PropertySearchModel();
      return View(propertyModel);
    }

    [HttpPost]
    public async Task<IActionResult> Properties(PropertySearchModel model)
    {
      var results = await _propertyDetailService.searchPropertyDetails(model);
      PropertyModel propertyModel = new PropertyModel();
      List<PropertyDetailViewModel> details = new List<PropertyDetailViewModel>();
      foreach (var item in results)
      {
        var propDetails = new PropertyDetailViewModel
        {
          Image = Convert.ToBase64String(item.PropertyImage?.FirstOrDefault().Image),
          Id = item.Id,
          NumOfbathrooms = item.NumOfbathrooms,
          NumOfBedrooms = item.NumOfBedrooms,
          LandSize = item.LandSize,
          NumOfGarages = item.NumOfGarages,
          NumOfKitchens = item.NumOfKitchens,
          NumOfParkingSpots = item.NumOfParkingSpots,
          NumOfReceptionRooms = item.NumOfReceptionRooms,
          PropertyAddress = item.PropertyAddress,
          PropertyDesc = item.PropertyDesc
        };
        details.Add(propDetails);
      }
      propertyModel.PropertyDetails = details;
      propertyModel.propertySearch = new PropertySearchModel();
      return View(propertyModel);
    }

    public async Task<IActionResult> PropertyDetails(int Id)
    {
      var results = await _propertyDetailService.getPropertyDetails(Id);
      var propertyDetails =  new PropertyDetailViewModel
      {
        Image = Convert.ToBase64String(results.PropertyImage?.FirstOrDefault().Image),
        Id = results.Id,
        NumOfbathrooms = results.NumOfbathrooms,
        NumOfBedrooms = results.NumOfBedrooms,
        LandSize = results.LandSize,
        NumOfGarages = results.NumOfGarages,
        NumOfKitchens = results.NumOfKitchens,
        NumOfParkingSpots = results.NumOfParkingSpots,
        NumOfReceptionRooms = results.NumOfReceptionRooms,
        PropertyAddress = results.PropertyAddress,
        PropertyDesc = results.PropertyDesc
      }; ;

      return View(propertyDetails);
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
