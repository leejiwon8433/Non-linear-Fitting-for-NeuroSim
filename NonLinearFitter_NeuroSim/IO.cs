using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearFitter_NeuroSim {
  internal class IO {
    public static List<Point> ReadLtpLtdTsvFile(string path) {
      var lines = File.ReadAllLines(path);
      List<Point> points = new List<Point>(lines.Length - 1);
      for (int i = 1; i < lines.Length; i++) {
        var strValues = lines[i].Trim().Split('\t');
        Point point = new() {
          X = double.Parse(strValues[0]),
          Y = double.Parse(strValues[1]),
        };
        points.Add(point);
      }

      return points;
    }

    public static void WriteFittedLtpLtdFile(List<Point> points, string path) {
      StringBuilder builder = new();
      builder.AppendLine("Normalized_Pulse_#\tNormalized_Conductance");
      points.ForEach(point => builder.AppendLine($"{point.X}\t{point.Y}"));
      File.WriteAllText(path, builder.ToString());
    }
  }
}
