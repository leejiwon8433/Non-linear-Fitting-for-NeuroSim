using DevExpress.Spreadsheet.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.Design;
using System.IO;

namespace NonLinearFitter_NeurosimV3 {
  using Series = DevExpress.XtraCharts.Series;

  public partial class Form1: DevExpress.XtraBars.Ribbon.RibbonForm {
    private LtpLtd _loadedRawLtpLtd;
    private NormalizedData _loadedLTP;
    private NormalizedData _loadedLTD;
    private NormalizedData _fittedLTP;
    private NormalizedData _fittedLTD;
    private Series _loadedLtpSeries;
    private Series _loadedLtdSeries;
    private Series _fittedLtpSeries;
    private Series _fittedLtdSeries;

    public Form1() {
      InitializeComponent();
      txt_NormALTP.EditValue = FittingOption.NormALTP.ToString();
      txt_NormALTD.EditValue = FittingOption.NormALTD.ToString();
    }

    private void btn_LoadRawData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
      using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
        openFileDialog.InitialDirectory = "C:\\"; // 초기 디렉토리 설정
        openFileDialog.Filter = "Raw LTP/LTD data (*.tsv)|*.tsv"; // 지원하는 파일 형식 설정

        if (openFileDialog.ShowDialog() == DialogResult.OK) {
          try {
            _loadedRawLtpLtd = LtpLtd.FromRawDataFile(openFileDialog.FileName);
            _loadedLTP?.Values?.Clear();
            _loadedLTD?.Values?.Clear();
            _fittedLTP?.Values?.Clear();
            _fittedLTD?.Values?.Clear();
            crt_LTP.Series.Clear();
            crt_LTD.Series.Clear();

            _loadedLTP = new NormalizedData(_loadedRawLtpLtd.LTPs, NormalizedData.DataType.Forward);
            _loadedLTD = new NormalizedData(_loadedRawLtpLtd.LTDs, NormalizedData.DataType.Reverse);
            InitializeControlsForRawData();
          } catch (Exception ex) {
            MessageBox.Show(ex.Message, "Error");
          }
        }
      }
    }

    private void InitializeControlsForRawData() {
      grd_RawLTP.DataSource = _loadedLTP.Values;
      grd_RawLTD.DataSource = _loadedLTD.Values;
      grd_RawLTP.RefreshDataSource();
      grd_RawLTD.RefreshDataSource();

      _loadedLtpSeries = new Series("Loaded_LTP", ViewType.Point);
      for (int i = 0; i < _loadedLTP.Values.Count; i++)
        _loadedLtpSeries.Points.Add(new SeriesPoint(_loadedLTP.Values[i].Pulse.ToString("0.000E0"),
                                                    _loadedLTP.Values[i].Conductance.ToString("0.000E+0")));

      _loadedLtdSeries = new Series("Loaded_LTD", ViewType.Point);
      for (int i = 0; i < _loadedLTD.Values.Count; i++)
        _loadedLtdSeries.Points.Add(new SeriesPoint(_loadedLTD.Values[i].Pulse.ToString("0.000E+0"),
                                                    _loadedLTD.Values[i].Conductance.ToString("0.000E+0")));

      crt_LTP.Series.Add(_loadedLtpSeries);
      crt_LTD.Series.Add(_loadedLtdSeries);
    }

    private void btn_SaveFittedData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
      try {
        LtpLtd fitted = new();
        fitted.LTPs.Capacity = _fittedLTP.Values.Count;
        fitted.LTDs.Capacity = _fittedLTD.Values.Count;
        foreach (var ltp in _fittedLTP.Values)
          fitted.LTPs.Add(new Point() { X = ltp.Pulse, Y = ltp.Conductance });
        foreach (var ltd in _fittedLTD.Values)
          fitted.LTDs.Add(new Point() { X = ltd.Pulse, Y = ltd.Conductance });

        using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
          saveFileDialog.Filter = "Fitted LTP/LTD file (*.tsv)|*.tsv";

          if (saveFileDialog.ShowDialog() == DialogResult.OK) {
            string filePath = saveFileDialog.FileName;

            StringBuilder builder = new();
            builder.AppendLine($"Pulse_#_LTP - Raw: {_loadedLTP.Values.Count}, Fitted: {_fittedLTP.Values.Count}");
            builder.AppendLine($"Pulse_#_LTD - Raw: {_loadedLTD.Values.Count}, Fitted: {_fittedLTD.Values.Count}");
            builder.Append(fitted.SerializeFittedData());

            File.WriteAllText(filePath, builder.ToString());
          }
        }
      } catch (Exception ex) {
        MessageBox.Show($"{ex.Message}");
      }
    }


    private void btn_FittingOption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
      FittingOptionForm fittingOptionForm = new FittingOptionForm();
      fittingOptionForm.StartPosition = FormStartPosition.CenterParent;
      fittingOptionForm.ShowDialog();
    }

    private void btn_Fit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
      try {
        NonLinearFitter fitter = new(_loadedRawLtpLtd.LTPs, _loadedRawLtpLtd.LTDs,
                                     FittingOption.CycleToCycleVariationLTP,
                                     FittingOption.CycleToCycleVariationLTD,
                                     FittingOption.RandomMin,
                                     FittingOption.RandomMax);
        var result = fitter.Fit();
        _fittedLTP = new(result.FittedLTPs, NormalizedData.DataType.Forward);
        _fittedLTD = new(result.FittedLTDs, NormalizedData.DataType.Forward);
        if (crt_LTP.Series.Count > 1)
          crt_LTP.Series.RemoveAt(1);
        if (crt_LTD.Series.Count > 1)
          crt_LTD.Series.RemoveAt(1);
        InitializeControlsForFittedData();
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Error");
      }
    }

    private void InitializeControlsForFittedData() {
      grd_FittedLTP.DataSource = _fittedLTP.Values;
      grd_FittedLTD.DataSource = _fittedLTD.Values;
      grd_FittedLTP.RefreshDataSource();
      grd_FittedLTD.RefreshDataSource();

      _fittedLtpSeries = new Series("Fitted_LTP", ViewType.Line);
      (_fittedLtpSeries.View as LineSeriesView).LineStyle.Thickness = 3;
      for (int i = 0; i < _fittedLTP.Values.Count; i++)
        _fittedLtpSeries.Points.Add(new SeriesPoint(_fittedLTP.Values[i].Pulse.ToString("0.000E0"),
                                                    _fittedLTP.Values[i].Conductance.ToString("0.000E+0")));

      _fittedLtdSeries = new Series("Fitted_LTD", ViewType.Line);
      (_fittedLtdSeries.View as LineSeriesView).LineStyle.Thickness = 3;
      for (int i = 0; i < _fittedLTD.Values.Count; i++)
        _fittedLtdSeries.Points.Add(new SeriesPoint(_fittedLTD.Values[i].Pulse.ToString("0.000E+0"),
                                                    _fittedLTD.Values[i].Conductance.ToString("0.000E+0")));

      crt_LTP.Series.Add(_fittedLtpSeries);
      crt_LTD.Series.Add(_fittedLtdSeries);
    }

    private void txt_NormALTP_EditValueChanged(object sender, EventArgs e) {
      if (txt_NormALTP.EditValue == null)
        return;

      if (double.TryParse(txt_NormALTP.EditValue.ToString(), out double normALtp))
        FittingOption.NormALTP = normALtp;
      else
        MessageBox.Show("Please check the NormA LTP value.");
    }

    private void txt_NormALTD_EditValueChanged(object sender, EventArgs e) {
      if (txt_NormALTD.EditValue == null)
        return;

      if (double.TryParse(txt_NormALTD.EditValue.ToString(), out double normALtd))
        FittingOption.NormALTD = normALtd;
      else
        MessageBox.Show("Please check the NormA LTD value.");
    }
  }
}
