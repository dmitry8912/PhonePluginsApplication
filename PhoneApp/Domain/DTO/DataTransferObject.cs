using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PhoneApp.Domain.DTO
{
  public abstract class DataTransferObject
  {
    public string ToJson()
    {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
  }
}
