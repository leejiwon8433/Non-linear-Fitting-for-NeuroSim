using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearFitter_NeurosimV3 {
  internal class LtpLtd {
    public List<Point> LTPs { get; set; }
    public List<Point> LTDs { get; set; }

    public LtpLtd() {
      LTPs = new();
      LTDs = new();
    }

    public static LtpLtd FromRawDataFile(string path) {
      try {
        var lines = File.ReadAllLines(path);
        List<Point> ltps = new List<Point>();
        List<Point> ltds = new List<Point>();
        for (int i = 1; i < lines.Length; i++) {
          if (string.IsNullOrEmpty(lines[i].Trim()))
            continue;

          var values = lines[i].Split('\t');
          bool existLtpX = !string.IsNullOrEmpty(values[0]);
          bool existLtpY = !string.IsNullOrEmpty(values[1]);
          bool existLtdX = !string.IsNullOrEmpty(values[2]);
          bool existLtdY = !string.IsNullOrEmpty(values[3]);
          if (existLtpX != existLtpY || existLtdX != existLtdY)
            throw new Exception("Empty data exists.");

          if (existLtpX) {
            Point ltp = new();
            if (double.TryParse(values[0], out double ltpX))
              ltp.X = ltpX;
            else
              throw new Exception($"Non-numeric data exists in line {i + 1}.");
            if (double.TryParse(values[1], out double ltpY))
              ltp.Y = ltpY;
            else
              throw new Exception($"Non-numeric data exists in line {i + 1}.");
            ltps.Add(ltp);
          }

          if (existLtdX) {
            Point ltd = new();
            if (double.TryParse(values[2], out double ltdX))
              ltd.X = ltdX;
            else
              throw new Exception($"Non-numeric data exists in line {i + 1}.");
            if (double.TryParse(values[3], out double ltdY))
              ltd.Y = ltdY;
            else
              throw new Exception($"Non-numeric data exists in line {i + 1}.");
            ltds.Add(ltd);
          }
        }

        LtpLtd result = new() {
          LTPs = ltps,
          LTDs = ltds
        };

        return result;
      } catch (Exception ex) {
        throw new Exception(ex.Message, ex);
      }
    }

    public string SerializeFittedData() {
      StringBuilder builder = new();
      builder.AppendLine("Normalized_Pulse_#_LTP\tNormalized_Conductance_LTD\tNormalized_Pulse_#_LTD\tNormalized_Conductance_LTD");
      int loopSize = LTPs.Count > LTDs.Count ? LTPs.Count : LTPs.Count;
      for (int i = 0; i < loopSize; i++) {
        if (i < LTPs.Count)
          builder.Append($"{LTPs[i].X}\t{LTPs[i].Y}\t");
        else
          builder.Append("\t\t");

        if (i < LTDs.Count)
          builder.Append($"{LTDs[i].X}\t{LTDs[i].Y}\n");
        else
          builder.Append("\t\n");
      }

      return builder.ToString();
    }
  }
}
