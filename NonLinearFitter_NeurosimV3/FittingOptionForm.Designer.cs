namespace NonLinearFitter_NeurosimV3 {
  partial class FittingOptionForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      groupBox1 = new System.Windows.Forms.GroupBox();
      txt_CycleToCycleVariationLTD = new DevExpress.XtraEditors.TextEdit();
      txt_CycleToCycleVariationLTP = new DevExpress.XtraEditors.TextEdit();
      label2 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      labelControl1 = new DevExpress.XtraEditors.LabelControl();
      groupBox2 = new System.Windows.Forms.GroupBox();
      txt_RandomMax = new DevExpress.XtraEditors.TextEdit();
      txt_RandomMin = new DevExpress.XtraEditors.TextEdit();
      label4 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      btn_FittingOptionCancel = new System.Windows.Forms.Button();
      btn_FittingOptionApply = new System.Windows.Forms.Button();
      groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)txt_CycleToCycleVariationLTD.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txt_CycleToCycleVariationLTP.Properties).BeginInit();
      groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)txt_RandomMax.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txt_RandomMin.Properties).BeginInit();
      SuspendLayout();
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(txt_CycleToCycleVariationLTD);
      groupBox1.Controls.Add(txt_CycleToCycleVariationLTP);
      groupBox1.Controls.Add(label2);
      groupBox1.Controls.Add(label1);
      groupBox1.Location = new System.Drawing.Point(12, 47);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(172, 97);
      groupBox1.TabIndex = 0;
      groupBox1.TabStop = false;
      groupBox1.Text = "Cycle to Cycle Variation";
      // 
      // txt_CycleToCycleVariationLTD
      // 
      txt_CycleToCycleVariationLTD.Location = new System.Drawing.Point(47, 53);
      txt_CycleToCycleVariationLTD.Name = "txt_CycleToCycleVariationLTD";
      txt_CycleToCycleVariationLTD.Size = new System.Drawing.Size(100, 20);
      txt_CycleToCycleVariationLTD.TabIndex = 3;
      // 
      // txt_CycleToCycleVariationLTP
      // 
      txt_CycleToCycleVariationLTP.Location = new System.Drawing.Point(47, 27);
      txt_CycleToCycleVariationLTP.Name = "txt_CycleToCycleVariationLTP";
      txt_CycleToCycleVariationLTP.Size = new System.Drawing.Size(100, 20);
      txt_CycleToCycleVariationLTP.TabIndex = 2;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(15, 56);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(28, 15);
      label2.TabIndex = 1;
      label2.Text = "LTD";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(15, 30);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(26, 15);
      label1.TabIndex = 0;
      label1.Text = "LTP";
      // 
      // labelControl1
      // 
      labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      labelControl1.Appearance.Options.UseFont = true;
      labelControl1.Location = new System.Drawing.Point(12, 12);
      labelControl1.Name = "labelControl1";
      labelControl1.Size = new System.Drawing.Size(108, 19);
      labelControl1.TabIndex = 1;
      labelControl1.Text = "Fitting Option";
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(txt_RandomMax);
      groupBox2.Controls.Add(txt_RandomMin);
      groupBox2.Controls.Add(label4);
      groupBox2.Controls.Add(label3);
      groupBox2.Location = new System.Drawing.Point(190, 47);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(203, 97);
      groupBox2.TabIndex = 1;
      groupBox2.TabStop = false;
      groupBox2.Text = "Random";
      // 
      // txt_RandomMax
      // 
      txt_RandomMax.Location = new System.Drawing.Point(81, 53);
      txt_RandomMax.Name = "txt_RandomMax";
      txt_RandomMax.Size = new System.Drawing.Size(100, 20);
      txt_RandomMax.TabIndex = 3;
      // 
      // txt_RandomMin
      // 
      txt_RandomMin.Location = new System.Drawing.Point(81, 27);
      txt_RandomMin.Name = "txt_RandomMin";
      txt_RandomMin.Size = new System.Drawing.Size(100, 20);
      txt_RandomMin.TabIndex = 2;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(15, 56);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(62, 15);
      label4.TabIndex = 1;
      label4.Text = "Maximum";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(15, 30);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(60, 15);
      label3.TabIndex = 0;
      label3.Text = "Minimum";
      // 
      // btn_FittingOptionCancel
      // 
      btn_FittingOptionCancel.Location = new System.Drawing.Point(318, 155);
      btn_FittingOptionCancel.Name = "btn_FittingOptionCancel";
      btn_FittingOptionCancel.Size = new System.Drawing.Size(75, 23);
      btn_FittingOptionCancel.TabIndex = 3;
      btn_FittingOptionCancel.Text = "Cancel";
      btn_FittingOptionCancel.UseVisualStyleBackColor = true;
      // 
      // btn_FittingOptionApply
      // 
      btn_FittingOptionApply.Location = new System.Drawing.Point(237, 155);
      btn_FittingOptionApply.Name = "btn_FittingOptionApply";
      btn_FittingOptionApply.Size = new System.Drawing.Size(75, 23);
      btn_FittingOptionApply.TabIndex = 2;
      btn_FittingOptionApply.Text = "Apply";
      btn_FittingOptionApply.UseVisualStyleBackColor = true;
      btn_FittingOptionApply.Click += btn_FittingOptionApply_Click;
      // 
      // FittingOptionForm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(406, 190);
      Controls.Add(btn_FittingOptionApply);
      Controls.Add(btn_FittingOptionCancel);
      Controls.Add(groupBox2);
      Controls.Add(labelControl1);
      Controls.Add(groupBox1);
      Name = "FittingOptionForm";
      Text = "Fitting Option";
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)txt_CycleToCycleVariationLTD.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)txt_CycleToCycleVariationLTP.Properties).EndInit();
      groupBox2.ResumeLayout(false);
      groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)txt_RandomMax.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)txt_RandomMin.Properties).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private DevExpress.XtraEditors.TextEdit txt_CycleToCycleVariationLTD;
    private DevExpress.XtraEditors.TextEdit txt_CycleToCycleVariationLTP;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private DevExpress.XtraEditors.TextEdit txt_RandomMax;
    private DevExpress.XtraEditors.TextEdit txt_RandomMin;
    private System.Windows.Forms.Button btn_FittingOptionCancel;
    private System.Windows.Forms.Button btn_FittingOptionApply;
  }
}