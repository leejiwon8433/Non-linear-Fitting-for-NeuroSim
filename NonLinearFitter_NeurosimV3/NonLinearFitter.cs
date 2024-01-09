using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearFitter_NeurosimV3 {
  internal class NonLinearFitter {
    internal class Result {
      public List<Point> FittedLTPs { get; set; }
      public List<Point> FittedLTDs { get; set; }

      public Result() {
        FittedLTPs = new();
        FittedLTDs = new();
      }
    }

    public List<Point> LTPs { get; set; }
    public List<Point> LTDs { get; set; }
    public double RandomMin { get; set; }
    public double RandomMax { get; set; }
    public double CycleToCycleVariationLTP { get; set; }
    public double CycleToCycleVariationLTD { get; set; }

    public NonLinearFitter(List<Point> ltps, List<Point> ltds,
                           double cycleToCycleVariationLTP,
                           double cycleToCycleVariationLTD,
                           double randomMin,
                           double randomMax) {
      LTPs = ltps;
      LTDs = ltds;
      RandomMin = randomMin;
      RandomMax = randomMax;
      CycleToCycleVariationLTP = cycleToCycleVariationLTP;
      CycleToCycleVariationLTD = cycleToCycleVariationLTD;
    }

    public Result Fit() {
      double epsilon = 1e-9;

      Result result = new();

      List<double> xs_LTP = LTPs.Select(p => p.X).ToList();
      List<double> xs_LTD = LTDs.Select(p => p.X).ToList();
      double maxX_LTP = Math.Floor(xs_LTP.Max());
      double maxX_LTD = Math.Floor(xs_LTD.Max());
      double xStep_LTP = 1 / maxX_LTP;
      double xStep_LTD = 1 / maxX_LTD;

      List<double> ys_LTP = LTPs.Select(p => p.Y).ToList();
      List<double> ys_LTD = LTDs.Select(p => p.Y).ToList();
      double maxY_LTP = ys_LTP.Max();
      double minY_LTP = ys_LTP.Min();
      double maxY_LTD = ys_LTD.Max();
      double minY_LTD = ys_LTD.Min();

      // Normalization
      List<Point> NormLTPs = new(LTPs.Count);
      for (int i = 0; i < LTPs.Count; i++) {
        Point point = new() {
          X = LTPs[i].X / maxX_LTP,
          Y = (LTPs[i].Y - minY_LTP) /
              (maxY_LTP - minY_LTP)
        };
        NormLTPs.Add(point);
      }

      List<Point> NormLTDs = new(LTDs.Count);
      for (int i = 0; i < LTDs.Count; i++) {
        Point point = new() {
          X = LTDs[i].X / maxX_LTD,
          Y = (LTDs[i].Y - minY_LTD) /
              (maxY_LTD - minY_LTD)
        };
        NormLTDs.Add(point);
      }

      // LTP fitting
      double A_LTP = FittingOption.NormALTP + epsilon;
      double B_LTP = 1.0 / (1 - Math.Exp(-1.0 / A_LTP));

      int loopSize = (int)(1.0 / xStep_LTP + 1);
      List<Point> fittedLTPs = new(loopSize) {
        new Point() { X = 0, Y = 0 }
      };
      for (int i = 0; i < loopSize; i++) {
        double nextX = fittedLTPs[i].X + xStep_LTP;
        double nextY = B_LTP * (1 - Math.Exp(-nextX / A_LTP));
        double deltaY = (nextY - fittedLTPs[i].Y) + Util.Random(RandomMin, RandomMax) * CycleToCycleVariationLTP;
        nextY = fittedLTPs[i].Y + deltaY;
        if (nextY >= 1)
          nextY = 1;
        else if (nextY <= 0)
          nextY = 0;

        nextX = -A_LTP * Math.Log(1 - nextY / B_LTP);

        Point next = new() {
          X = nextX,
          Y = nextY
        };
        fittedLTPs.Add(next);
      }
      fittedLTPs.RemoveAt(fittedLTPs.Count - 1);
      for (int i = 0; i < fittedLTPs.Count; i++)
        fittedLTPs[i].X = (double)i / (fittedLTPs.Count - 1);

      result.FittedLTPs = fittedLTPs;

      // LTD fitting
      double A_LTD = FittingOption.NormALTD - epsilon;
      double B_LTD = 1.0 / (1 - Math.Exp(-1.0 / A_LTD));

      loopSize = (int)(1.0 / xStep_LTD + 1);
      List<Point> fittedLTDs = new(loopSize) {
        new Point() { X = 1, Y = 1 }
      };
      for (int i = 0; i < loopSize; i++) {
        double nextX = fittedLTDs[i].X - xStep_LTD;
        double nextY = B_LTD * (1 - Math.Exp(-nextX / A_LTD));
        double deltaY = (nextY - fittedLTDs[i].Y) + Util.Random(RandomMin, RandomMax) * CycleToCycleVariationLTD;
        nextY = fittedLTDs[i].Y + deltaY;
        if (nextY >= 1)
          nextY = 1;
        else if (nextY <= 0)
          nextY = 0;

        nextX = -A_LTD * Math.Log(1 - nextY / B_LTD);

        Point next = new() {
          X = nextX,
          Y = nextY
        };
        fittedLTDs.Add(next);
      }
      fittedLTDs.RemoveAt(fittedLTDs.Count - 1);

      List<Point> reverseFittedLTDs = new(fittedLTDs.Count);
      for (int i = 0; i < fittedLTDs.Count; i++) {
        Point point = new() {
          X = (double)(fittedLTDs.Count - i - 1) / (fittedLTDs.Count - 1),
          Y = fittedLTDs[i].Y
        };
        reverseFittedLTDs.Add(point);
      }

      result.FittedLTDs = reverseFittedLTDs;
      return result;
    }
  }
}
