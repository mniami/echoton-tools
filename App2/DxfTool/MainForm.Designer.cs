﻿namespace DxfTool;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ofdSource = new OpenFileDialog();
        ofdDestination = new OpenFileDialog();
        toolStrip1 = new ToolStrip();
        txtDxfHighPointName = new TextBox();
        groupBox1 = new GroupBox();
        btnExportGpsFromDxf = new Button();
        label1 = new Label();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // ofdSource
        // 
        ofdSource.FileName = "plik.dxf";
        ofdSource.Filter = "DXF pliki|*.dxf";
        // 
        // ofdDestination
        // 
        ofdDestination.CheckFileExists = false;
        ofdDestination.CheckPathExists = false;
        ofdDestination.DefaultExt = "*.csv";
        ofdDestination.FileName = "export.csv";
        ofdDestination.Filter = "CSV plik|*.csv";
        ofdDestination.SelectReadOnly = false;
        // 
        // toolStrip1
        // 
        toolStrip1.Location = new Point(0, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(800, 25);
        toolStrip1.TabIndex = 0;
        toolStrip1.Text = "toolStrip1";
        // 
        // txtDxfHighPointName
        // 
        txtDxfHighPointName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtDxfHighPointName.Location = new Point(6, 38);
        txtDxfHighPointName.Name = "txtDxfHighPointName";
        txtDxfHighPointName.Size = new Size(346, 23);
        txtDxfHighPointName.TabIndex = 1;
        txtDxfHighPointName.Text = "punkt wysoko";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(btnExportGpsFromDxf);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(txtDxfHighPointName);
        groupBox1.Location = new Point(12, 28);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(358, 101);
        groupBox1.TabIndex = 2;
        groupBox1.TabStop = false;
        groupBox1.Text = "Export GPS z DXF";
        // 
        // btnExportGpsFromDxf
        // 
        btnExportGpsFromDxf.Location = new Point(6, 67);
        btnExportGpsFromDxf.Name = "btnExportGpsFromDxf";
        btnExportGpsFromDxf.Size = new Size(75, 23);
        btnExportGpsFromDxf.TabIndex = 3;
        btnExportGpsFromDxf.Text = "Eksportuj";
        btnExportGpsFromDxf.UseVisualStyleBackColor = true;
        btnExportGpsFromDxf.Click += btnExportGpsFromDxf_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(6, 19);
        label1.Name = "label1";
        label1.Size = new Size(176, 15);
        label1.TabIndex = 2;
        label1.Text = "Nazwa punktu wysokościowego";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(groupBox1);
        Controls.Add(toolStrip1);
        Name = "MainForm";
        Text = "DxfTool";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private OpenFileDialog ofdSource;
    private OpenFileDialog ofdDestination;
    private ToolStrip toolStrip1;
    private TextBox txtDxfHighPointName;
    private GroupBox groupBox1;
    private Button btnExportGpsFromDxf;
    private Label label1;
}
