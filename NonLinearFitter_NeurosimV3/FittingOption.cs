using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearFitter_NeurosimV3 {
  internal class FittingOption {
    public static double NormALTP { get; set; }
    public static double NormALTD { get; set; }
    public static double RandomMin { get; set; }
    public static double RandomMax { get; set; }
    public static double CycleToCycleVariationLTP { get; set; }
    public static double CycleToCycleVariationLTD { get; set; }

    static FittingOption() {
      NormALTP = 1;
      NormALTD = -1;
      RandomMin = -1;
      RandomMax = 1;
      CycleToCycleVariationLTP = 0;
      CycleToCycleVariationLTD = 0;
    }
  }
}
