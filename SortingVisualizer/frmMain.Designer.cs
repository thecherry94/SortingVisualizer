namespace SortingVisualizer
{
    partial class frmMain
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
            this.pcbCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbCanvas
            // 
            this.pcbCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbCanvas.BackColor = System.Drawing.Color.Black;
            this.pcbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbCanvas.Location = new System.Drawing.Point(12, 12);
            this.pcbCanvas.Name = "pcbCanvas";
            this.pcbCanvas.Size = new System.Drawing.Size(893, 728);
            this.pcbCanvas.TabIndex = 0;
            this.pcbCanvas.TabStop = false;
            this.pcbCanvas.Click += new System.EventHandler(this.pcbCanvas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(911, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 752);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pcbCanvas);
            this.Name = "frmMain";
            this.Text = "Sorting Visualizer";
            ((System.ComponentModel.ISupportInitialize)(this.pcbCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbCanvas;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

