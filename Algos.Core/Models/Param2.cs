using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Core.Models
{
  public class Param2
  {
    public string Name { get; set; }
    public string ParamType { get; set; }

    public Param2(string name, string paramType) {
      Name = name;
      ParamType = paramType;
    }

  }
}
