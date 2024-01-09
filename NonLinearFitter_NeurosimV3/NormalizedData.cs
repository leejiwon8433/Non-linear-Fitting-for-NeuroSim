using DevExpress.Pdf.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearFitter_NeurosimV3 {
  internal class NormalizedData {
    public class Value {
      public double Pulse { get; set; }
      public double Conductance { get; set; }
    }

    public ObservableCollection<Value> Values { get; set; }

    public NormalizedData() {
      Values = new ObservableCollection<Value>();
    }

    public enum DataType {
      Forward,
      Reverse
    }
    public NormalizedData(List<Point> points, DataType type) {
      List<double> xs = points.Select(p => p.X).ToList();
      List<double> ys = points.Select(p => p.Y).ToList();

      double minX = xs.Min(),
             maxX = xs.Max(),
             minY = ys.Min(),
             maxY = ys.Max();

      Values = new ObservableCollection<Value>();
      for (int i = 0; i < points.Count; i++) {
        Value value = new() {
          Pulse = (type == DataType.Forward) ?
                  (double)i / (points.Count - 1) :
                  (double)(points.Count - i - 1) / (points.Count - 1),
          Conductance = (points[i].Y - minY) /
                        (maxY - minY)
        };
        //value.Pulse = Math.Round(value.Pulse, 8);
        //value.Conductance = Math.Round(value.Conductance, 8);
        Values.Add(value);
      }
    }


  }
}
