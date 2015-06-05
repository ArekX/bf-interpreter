namespace BrainFuckInterpreter
{
    partial class DebugForm
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
            this.lstDebug = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstDebug
            // 
            this.lstDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDebug.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDebug.FormattingEnabled = true;
            this.lstDebug.ItemHeight = 15;
            this.lstDebug.Location = new System.Drawing.Point(12, 12);
            this.lstDebug.Name = "lstDebug";
            this.lstDebug.ScrollAlwaysVisible = true;
            this.lstDebug.Size = new System.Drawing.Size(222, 244);
            this.lstDebug.TabIndex = 0;
            this.lstDebug.SelectedIndexChanged += new System.EventHandler(this.lstDebug_SelectedIndexChanged);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 268);
            this.Controls.Add(this.lstDebug);
            this.Name = "DebugForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Debug Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDebug;
    }
}