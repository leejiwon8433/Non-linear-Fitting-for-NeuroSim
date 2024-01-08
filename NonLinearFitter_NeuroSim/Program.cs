namespace NonLinearFitter_NeuroSim {
  internal class Program {
    static void Main(string[] args) {
      List<Point> ltps = IO.ReadLtpLtdTsvFile("LTP_raw_test.tsv");
      List<Point> ltds = IO.ReadLtpLtdTsvFile("LTD_raw_test.tsv");

      //NonLinearFitter fitter = new NonLinearFitter(ltps, ltds, 0.035, 0.025);
      NonLinearFitter fitter = new NonLinearFitter(ltps, ltds);
      var result = fitter.Fit();
      IO.WriteFittedLtpLtdFile(result.FittedLTPs, "fitted_ltp.tsv");
      IO.WriteFittedLtpLtdFile(result.FittedLTDs, "fitted_ltd.tsv");
    }
  }
}
