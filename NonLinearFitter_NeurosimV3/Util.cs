using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearFitter_NeurosimV3 {
  internal class Util {
    private static readonly Random _random = new();

    public static double Random(double min, double max) {
      double randomValue = (_random.NextDouble() * (max - min)) + min;
      return randomValue;
    }
  }
}
