namespace UiEditor
{
    partial class UiPropertyGrid
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mNameLabel = new System.Windows.Forms.Label();
            this.mEditor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mNameLabel
            // 
            this.mNameLabel.AutoSize = true;
            this.mNameLabel.Location = new System.Drawing.Point(4, 4);
            this.mNameLabel.Name = "mNameLabel";
            this.mNameLabel.Size = new System.Drawing.Size(41, 12);
            this.mNameLabel.TabIndex = 0;
            this.mNameLabel.Text = "label1";
            // 
            // mEditor
            // 
            this.mEditor.Location = new System.Drawing.Point(77, -1);
            this.mEditor.Name = "mEditor";
            this.mEditor.Size = new System.Drawing.Size(167, 21);
            this.mEditor.TabIndex = 1;
            this.mEditor.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // UiPropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mEditor);
            this.Controls.Add(this.mNameLabel);
            this.Name = "UiPropertyGrid";
            this.Size = new System.Drawing.Size(244, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mNameLabel;
        private System.Windows.Forms.TextBox mEditor;
    }
}
