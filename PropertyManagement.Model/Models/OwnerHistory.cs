using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyManagement.Model.Models
{
  public class OwnerHistory
  {
    [Key]
    public int Id { get; set; }
    public int PropertyDetailId { get; set; }
    public string OwnerName { get; set; }
    public DateTime DateBought { get; set; }
    public DateTime? DateSold { get; set; }
    public decimal BuyingPrice { get; set; }
    public decimal? SellingPrice { get; set; }
    public bool IsCurrentOwner { get; set; }
  }
}
