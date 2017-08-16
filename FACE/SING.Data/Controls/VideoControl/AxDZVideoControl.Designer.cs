namespace SING.Data.Controls.VideoControl
{
    partial class AxDZVideoControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxDZVideoControl));
            this.axVideoOCX1 = new AxVideoOCXLib.AxVideoOCX();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoOCX1)).BeginInit();
            this.SuspendLayout();
            // 
            // axVideoOCX1
            // 
            this.axVideoOCX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVideoOCX1.Enabled = true;
            this.axVideoOCX1.Location = new System.Drawing.Point(0, 0);
            this.axVideoOCX1.Name = "axVideoOCX1";
            this.axVideoOCX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoOCX1.OcxState")));
            this.axVideoOCX1.Size = new System.Drawing.Size(150, 150);
            this.axVideoOCX1.TabIndex = 0;
            // 
            // AxDZVideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axVideoOCX1);
            this.Name = "AxDZVideoControl";
            ((System.ComponentModel.ISupportInitialize)(this.axVideoOCX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxVideoOCXLib.AxVideoOCX axVideoOCX1;
    }
}
