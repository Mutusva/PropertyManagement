using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PropertyManagement.UI.Models
{
  [DataContract]
  public class DataPoint
  {   
    public DataPoint(double x, double y,string legendText)
    {
      this.X = x;
      this.Y = y;
      this.LegendText = legendText;
    }

    //Explicitly setting the name to be used while serializing to JSON.
    [DataMember(Name = "x")]
    public Nullable<double> X = null;

    [DataMember(Name = "legendText")]
    public string LegendText;
    //Explicitly setting the name to be used while serializing to JSON.
    [DataMember(Name = "y")]
    public Nullable<double> Y = null;
  }
}
