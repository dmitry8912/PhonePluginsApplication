using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp.Domain.DTO;
namespace PhoneApp.Domain.Interfaces
{
  public interface IPluggable
  {
    IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args);
  }
}
