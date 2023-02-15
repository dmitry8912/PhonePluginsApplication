using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.Domain.Attributes
{
  public class Author : Attribute
  {
    public string Name { get; set; }
    public override string ToString()
    {
      return this.Name;
    }
  }
}
