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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mDesignWidget = new UiEditor.UiDesignWidget();
            this.mPreviewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mPreviewPanel
            // 
            this.mPreviewPanel.Controls.Add(this.panel1);
            this.mPreviewPanel.Location = new System.Drawing.Point(778, -2);
            this.mPreviewPanel.Name = "mPreviewPanel";
            this.mPreviewPanel.Size = new System.Drawing.Size(640, 960);
            this.mPreviewPanel.TabIndex = 0;
            // 
            // mTimeTick
            // 
            this.mTimeTick.Enabled = true;
            this.mTimeTick.Tick += new System.EventHandler(this.OnTimeTick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 960);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.OnClick);
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
            this.ClientSize = new System.Drawing.Size(1430, 970);
            this.Controls.Add(this.mDesignWidget);
            this.Controls.Add(this.mPreviewPanel);
            this.Name = "UiEditorForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.mPreviewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mPreviewPanel;
        private System.Windows.Forms.Timer mTimeTick;
        private UiDesignWidget mDesignWidget;
        private System.Windows.Forms.Panel panel1;
    }
}

