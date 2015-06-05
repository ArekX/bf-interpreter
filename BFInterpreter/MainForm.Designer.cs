namespace BrainFuckInterpreter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scnCode = new ScintillaNET.Scintilla();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEndIsNull = new System.Windows.Forms.CheckBox();
            this.chkConstant = new System.Windows.Forms.CheckBox();
            this.chkFillDebugEnd = new System.Windows.Forms.CheckBox();
            this.nmMemorySize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.scnCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMemorySize)).BeginInit();
            this.SuspendLayout();
            // 
            // scnCode
            // 
            this.scnCode.AllowDrop = true;
            this.scnCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scnCode.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scnCode.Location = new System.Drawing.Point(0, 59);
            this.scnCode.Name = "scnCode";
            this.scnCode.Size = new System.Drawing.Size(625, 284);
            this.scnCode.Styles.BraceBad.Size = 9F;
            this.scnCode.Styles.BraceLight.Size = 9F;
            this.scnCode.Styles.ControlChar.Size = 9F;
            this.scnCode.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scnCode.Styles.Default.Size = 9F;
            this.scnCode.Styles.IndentGuide.Size = 9F;
            this.scnCode.Styles.LastPredefined.Size = 9F;
            this.scnCode.Styles.LineNumber.IsHotspot = true;
            this.scnCode.Styles.LineNumber.Size = 9F;
            this.scnCode.Styles.Max.Size = 9F;
            this.scnCode.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(523, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(99, 24);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run (F5)";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebug.Location = new System.Drawing.Point(418, 6);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(99, 24);
            this.btnDebug.TabIndex = 3;
            this.btnDebug.Text = "Debug (F4)";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(52, 10);
            this.txtInput.MaxLength = 0;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(205, 20);
            this.txtInput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input:";
            // 
            // chkEndIsNull
            // 
            this.chkEndIsNull.AutoSize = true;
            this.chkEndIsNull.Checked = true;
            this.chkEndIsNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEndIsNull.Location = new System.Drawing.Point(15, 36);
            this.chkEndIsNull.Name = "chkEndIsNull";
            this.chkEndIsNull.Size = new System.Drawing.Size(102, 17);
            this.chkEndIsNull.TabIndex = 6;
            this.chkEndIsNull.Text = "Null terminated?";
            this.chkEndIsNull.UseVisualStyleBackColor = true;
            // 
            // chkConstant
            // 
            this.chkConstant.AutoSize = true;
            this.chkConstant.Checked = true;
            this.chkConstant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConstant.Location = new System.Drawing.Point(117, 36);
            this.chkConstant.Name = "chkConstant";
            this.chkConstant.Size = new System.Drawing.Size(107, 17);
            this.chkConstant.TabIndex = 7;
            this.chkConstant.Text = "Constant output?";
            this.chkConstant.UseVisualStyleBackColor = true;
            // 
            // chkFillDebugEnd
            // 
            this.chkFillDebugEnd.AutoSize = true;
            this.chkFillDebugEnd.Location = new System.Drawing.Point(230, 36);
            this.chkFillDebugEnd.Name = "chkFillDebugEnd";
            this.chkFillDebugEnd.Size = new System.Drawing.Size(128, 17);
            this.chkFillDebugEnd.TabIndex = 8;
            this.chkFillDebugEnd.Text = "Fill debug at the end?";
            this.chkFillDebugEnd.UseVisualStyleBackColor = true;
            // 
            // nmMemorySize
            // 
            this.nmMemorySize.Location = new System.Drawing.Point(498, 35);
            this.nmMemorySize.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nmMemorySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMemorySize.Name = "nmMemorySize";
            this.nmMemorySize.Size = new System.Drawing.Size(120, 20);
            this.nmMemorySize.TabIndex = 9;
            this.nmMemorySize.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Memory size:";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "BF Files|*.b|All files|*.*";
            this.dlgOpen.Title = "Open BF file...";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(263, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 24);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(343, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(69, 24);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "BF Files|*.b";
            this.dlgSave.Title = "Save BF File...";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 342);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmMemorySize);
            this.Controls.Add(this.chkFillDebugEnd);
            this.Controls.Add(this.chkConstant);
            this.Controls.Add(this.chkEndIsNull);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.scnCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(640, 380);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BF Interpreter IDE (by Panic Aleksandar)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.scnCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMemorySize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNET.Scintilla scnCode;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEndIsNull;
        private System.Windows.Forms.NumericUpDown nmMemorySize;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox chkFillDebugEnd;
        public System.Windows.Forms.CheckBox chkConstant;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}

