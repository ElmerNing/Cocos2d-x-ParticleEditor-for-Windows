namespace UiEditor
{
    partial class UiEditorForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mPreviewPanel = new System.Windows.Forms.Panel();
            this.mTimeTick = new System.Windows.Forms.Timer(this.components);
            this.mDesignWidget = new UiEditor.UiDesignWidget();
            this.SuspendLayout();
            // 
            // mPreviewPanel
            // 
            this.mPreviewPanel.Location = new System.Drawing.Point(673, 25);
            this.mPreviewPanel.Name = "mPreviewPanel";
            this.mPreviewPanel.Size = new System.Drawing.Size(640, 960);
            this.mPreviewPanel.TabIndex = 0;
            // 
            // mTimeTick
            // 
            this.mTimeTick.Enabled = true;
            this.mTimeTick.Tick += new System.EventHandler(this.OnTimeTick);
            // 
            // mDesignWidget
            // 
            this.mDesignWidget.Location = new System.Drawing.Point(12, 15);
            this.mDesignWidget.Name = "mDesignWidget";
            this.mDesignWidget.Size = new System.Drawing.Size(734, 1092);
            this.mDesignWidget.TabIndex = 1;
            // 
            // UiEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 750);
            this.Controls.Add(this.mDesignWidget);
            this.Controls.Add(this.mPreviewPanel);
            this.Name = "UiEditorForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mPreviewPanel;
        private System.Windows.Forms.Timer mTimeTick;
        private UiDesignWidget mDesignWidget;
    }
}

