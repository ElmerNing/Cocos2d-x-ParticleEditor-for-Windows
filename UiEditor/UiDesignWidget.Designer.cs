namespace UiEditor
{
    partial class UiDesignWidget
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
            this.components = new System.ComponentModel.Container();
            this.mNodesTree = new System.Windows.Forms.TreeView();
            this.mContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cCNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCNodeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cCSpriteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cCSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mNewBtn = new System.Windows.Forms.Button();
            this.mSaveBtn = new System.Windows.Forms.Button();
            this.mPropertyWidget = new UiEditor.UiPropertyWidget();
            this.mOpenBtn = new System.Windows.Forms.Button();
            this.mSavePathLabel = new System.Windows.Forms.Label();
            this.mFreshBtn = new System.Windows.Forms.Button();
            this.mContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mNodesTree
            // 
            this.mNodesTree.ContextMenuStrip = this.mContextMenuStrip;
            this.mNodesTree.Location = new System.Drawing.Point(3, 3);
            this.mNodesTree.Name = "mNodesTree";
            this.mNodesTree.Size = new System.Drawing.Size(185, 960);
            this.mNodesTree.TabIndex = 0;
            this.mNodesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelect);
            // 
            // mContextMenuStrip
            // 
            this.mContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cCNodeToolStripMenuItem,
            this.cCSpriteToolStripMenuItem});
            this.mContextMenuStrip.Name = "mContextMenuStrip";
            this.mContextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // cCNodeToolStripMenuItem
            // 
            this.cCNodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cCNodeToolStripMenuItem1,
            this.cCSpriteToolStripMenuItem1});
            this.cCNodeToolStripMenuItem.Name = "cCNodeToolStripMenuItem";
            this.cCNodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cCNodeToolStripMenuItem.Text = "插入节点";
            this.cCNodeToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnInsertClick);
            // 
            // cCNodeToolStripMenuItem1
            // 
            this.cCNodeToolStripMenuItem1.Name = "cCNodeToolStripMenuItem1";
            this.cCNodeToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.cCNodeToolStripMenuItem1.Text = "CCNode";
            // 
            // cCSpriteToolStripMenuItem1
            // 
            this.cCSpriteToolStripMenuItem1.Name = "cCSpriteToolStripMenuItem1";
            this.cCSpriteToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.cCSpriteToolStripMenuItem1.Text = "CCSprite";
            // 
            // cCSpriteToolStripMenuItem
            // 
            this.cCSpriteToolStripMenuItem.Name = "cCSpriteToolStripMenuItem";
            this.cCSpriteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cCSpriteToolStripMenuItem.Text = "删除节点";
            this.cCSpriteToolStripMenuItem.Click += new System.EventHandler(this.OnDeleteClick);
            // 
            // mNewBtn
            // 
            this.mNewBtn.Location = new System.Drawing.Point(253, 36);
            this.mNewBtn.Name = "mNewBtn";
            this.mNewBtn.Size = new System.Drawing.Size(75, 23);
            this.mNewBtn.TabIndex = 1;
            this.mNewBtn.Text = "新建";
            this.mNewBtn.UseVisualStyleBackColor = true;
            this.mNewBtn.Click += new System.EventHandler(this.OnNewBtnClick);
            // 
            // mSaveBtn
            // 
            this.mSaveBtn.Location = new System.Drawing.Point(467, 36);
            this.mSaveBtn.Name = "mSaveBtn";
            this.mSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.mSaveBtn.TabIndex = 2;
            this.mSaveBtn.Text = "保存";
            this.mSaveBtn.UseVisualStyleBackColor = true;
            this.mSaveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
            // 
            // mPropertyWidget
            // 
            this.mPropertyWidget.Location = new System.Drawing.Point(253, 133);
            this.mPropertyWidget.Name = "mPropertyWidget";
            this.mPropertyWidget.Size = new System.Drawing.Size(379, 800);
            this.mPropertyWidget.TabIndex = 3;
            // 
            // mOpenBtn
            // 
            this.mOpenBtn.Location = new System.Drawing.Point(363, 36);
            this.mOpenBtn.Name = "mOpenBtn";
            this.mOpenBtn.Size = new System.Drawing.Size(75, 23);
            this.mOpenBtn.TabIndex = 4;
            this.mOpenBtn.Text = "打开";
            this.mOpenBtn.UseVisualStyleBackColor = true;
            this.mOpenBtn.Click += new System.EventHandler(this.OnOpenBtnClick);
            // 
            // mSavePathLabel
            // 
            this.mSavePathLabel.AutoSize = true;
            this.mSavePathLabel.Location = new System.Drawing.Point(251, 12);
            this.mSavePathLabel.Name = "mSavePathLabel";
            this.mSavePathLabel.Size = new System.Drawing.Size(0, 12);
            this.mSavePathLabel.TabIndex = 5;
            // 
            // mFreshBtn
            // 
            this.mFreshBtn.Location = new System.Drawing.Point(571, 35);
            this.mFreshBtn.Name = "mFreshBtn";
            this.mFreshBtn.Size = new System.Drawing.Size(75, 23);
            this.mFreshBtn.TabIndex = 6;
            this.mFreshBtn.Text = "刷新";
            this.mFreshBtn.UseVisualStyleBackColor = true;
            this.mFreshBtn.Click += new System.EventHandler(this.OnFreshClick);
            // 
            // UiDesignWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mFreshBtn);
            this.Controls.Add(this.mSavePathLabel);
            this.Controls.Add(this.mOpenBtn);
            this.Controls.Add(this.mPropertyWidget);
            this.Controls.Add(this.mNewBtn);
            this.Controls.Add(this.mSaveBtn);
            this.Controls.Add(this.mNodesTree);
            this.Name = "UiDesignWidget";
            this.Size = new System.Drawing.Size(723, 960);
            this.mContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView mNodesTree;
        private System.Windows.Forms.Button mNewBtn;
        private System.Windows.Forms.Button mSaveBtn;
        private UiPropertyWidget mPropertyWidget;
        private System.Windows.Forms.ContextMenuStrip mContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cCNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCNodeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cCSpriteToolStripMenuItem1;
        private System.Windows.Forms.Button mOpenBtn;
        private System.Windows.Forms.Label mSavePathLabel;
        private System.Windows.Forms.Button mFreshBtn;
    }
}
