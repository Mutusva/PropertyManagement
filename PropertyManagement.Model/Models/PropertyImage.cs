using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PropertyManagement.Model.Models
{
  public class PropertyImage
  {
    [Key]
    public int Id { get; set; }
    public int PropertyDetailId { get; set; }
    //public string Image { get; set; }
    public Byte[] Image { get; set; }
  }
}
