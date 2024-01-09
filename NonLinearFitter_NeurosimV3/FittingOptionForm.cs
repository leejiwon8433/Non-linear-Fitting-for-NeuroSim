using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonLinearFitter_NeurosimV3 {
  public partial class FittingOptionForm: Form {
    public FittingOptionForm() {
      InitializeComponent();
      txt_RandomMin.Text = FittingOption.RandomMin.ToString();
      txt_RandomMax.Text = FittingOption.RandomMax.ToString();
      txt_CycleToCycleVariationLTP.Text = FittingOption.CycleToCycleVariationLTP.ToString();
      txt_CycleToCycleVariationLTD.Text = FittingOption.CycleToCycleVariationLTD.ToString();
    }

    private void btn_FittingOptionApply_Click(object sender, EventArgs e) {
      bool valid = true;
      if (double.TryParse(txt_RandomMin.Text, out double randomMin))
        FittingOption.RandomMin = randomMin;
      else
        valid = false;

      if (double.TryParse(txt_RandomMax.Text, out double randomMax))
        FittingOption.RandomMax = randomMax;
      else
        valid = false;

      if (double.TryParse(txt_CycleToCycleVariationLTP.Text, out double CToC_LTP))
        FittingOption.CycleToCycleVariationLTP = CToC_LTP;
      else
        valid = false;

      if (double.TryParse(txt_CycleToCycleVariationLTD.Text, out double CToC_LTD))
        FittingOption.CycleToCycleVariationLTD = CToC_LTD;
      else
        valid = false;

      if (!valid) {
        MessageBox.Show("Please check the cycle to cycle variation LTD value.");
      } else {
        this.Close();
      }
    }
  }
}