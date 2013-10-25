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
            this.cCScale9SpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCLabelTTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCLabelTTFEXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCMenuItemSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCNodeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cCMenuItemSpriteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cCMenuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cCSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mNewBtn = new System.Windows.Forms.Button();
            this.mSaveBtn = new System.Windows.Forms.Button();
            this.mOpenBtn = new System.Windows.Forms.Button();
            this.mSavePathLabel = new System.Windows.Forms.Label();
            this.mFreshBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mPropertyWidget = new UiEditor.UiPropertyWidget();
            this.upbtn = new System.Windows.Forms.Button();
            this.downbtn = new System.Windows.Forms.Button();
            this.leftbtn = new System.Windows.Forms.Button();
            this.rightbtn = new System.Windows.Forms.Button();
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
            this.更改节点ToolStripMenuItem,
            this.cCSpriteToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.mContextMenuStrip.Name = "mContextMenuStrip";
            this.mContextMenuStrip.Size = new System.Drawing.Size(125, 92);
            // 
            // cCNodeToolStripMenuItem
            // 
            this.cCNodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cCNodeToolStripMenuItem1,
            this.cCSpriteToolStripMenuItem1,
            this.cCScale9SpriteToolStripMenuItem,
            this.cCLabelTTFToolStripMenuItem,
            this.cCLabelTTFEXToolStripMenuItem,
            this.cCMenuItemSpriteToolStripMenuItem,
            this.cCMenuToolStripMenuItem});
            this.cCNodeToolStripMenuItem.Name = "cCNodeToolStripMenuItem";
            this.cCNodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cCNodeToolStripMenuItem.Text = "插入节点";
            this.cCNodeToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnInsertClick);
            // 
            // cCNodeToolStripMenuItem1
            // 
            this.cCNodeToolStripMenuItem1.Name = "cCNodeToolStripMenuItem1";
            this.cCNodeToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cCNodeToolStripMenuItem1.Text = "CCNode";
            // 
            // cCSpriteToolStripMenuItem1
            // 
            this.cCSpriteToolStripMenuItem1.Name = "cCSpriteToolStripMenuItem1";
            this.cCSpriteToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cCSpriteToolStripMenuItem1.Text = "CCSprite";
            // 
            // cCScale9SpriteToolStripMenuItem
            // 
            this.cCScale9SpriteToolStripMenuItem.Name = "cCScale9SpriteToolStripMenuItem";
            this.cCScale9SpriteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cCScale9SpriteToolStripMenuItem.Text = "CCScale9Sprite";
            // 
            // cCLabelTTFToolStripMenuItem
            // 
            this.cCLabelTTFToolStripMenuItem.Name = "cCLabelTTFToolStripMenuItem";
            this.cCLabelTTFToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cCLabelTTFToolStripMenuItem.Text = "CCLabelTTF";
            // 
            // cCLabelTTFEXToolStripMenuItem
            // 
            this.cCLabelTTFEXToolStripMenuItem.Name = "cCLabelTTFEXToolStripMenuItem";
            this.cCLabelTTFEXToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cCLabelTTFEXToolStripMenuItem.Text = "CCLabelTTFEX";
            // 
            // cCMenuItemSpriteToolStripMenuItem
            // 
            this.cCMenuItemSpriteToolStripMenuItem.Name = "cCMenuItemSpriteToolStripMenuItem";
            this.cCMenuItemSpriteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cCMenuItemSpriteToolStripMenuItem.Text = "CCMenuItemSprite";
            // 
            // cCMenuToolStripMenuItem
            // 
            this.cCMenuToolStripMenuItem.Name = "cCMenuToolStripMenuItem";
            this.cCMenuToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cCMenuToolStripMenuItem.Text = "CCMenu";
            // 
            // 更改节点ToolStripMenuItem
            // 
            this.更改节点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cCNodeToolStripMenuItem2,
            this.cCToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.cCMenuItemSpriteToolStripMenuItem1,
            this.cCMenuToolStripMenuItem1});
            this.更改节点ToolStripMenuItem.Name = "更改节点ToolStripMenuItem";
            this.更改节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.更改节点ToolStripMenuItem.Text = "更改节点";
            this.更改节点ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnChangeItemClick);
            // 
            // cCNodeToolStripMenuItem2
            // 
            this.cCNodeToolStripMenuItem2.Name = "cCNodeToolStripMenuItem2";
            this.cCNodeToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.cCNodeToolStripMenuItem2.Text = "CCNode";
            // 
            // cCToolStripMenuItem
            // 
            this.cCToolStripMenuItem.Name = "cCToolStripMenuItem";
            this.cCToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cCToolStripMenuItem.Text = "CCSprite";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem1.Text = "CCLabelTTF";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem2.Text = "CCLabelTTFEX";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem3.Text = "CCScale9Sprite";
            // 
            // cCMenuItemSpriteToolStripMenuItem1
            // 
            this.cCMenuItemSpriteToolStripMenuItem1.Name = "cCMenuItemSpriteToolStripMenuItem1";
            this.cCMenuItemSpriteToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cCMenuItemSpriteToolStripMenuItem1.Text = "CCMenuItemSprite";
            // 
            // cCMenuToolStripMenuItem1
            // 
            this.cCMenuToolStripMenuItem1.Name = "cCMenuToolStripMenuItem1";
            this.cCMenuToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cCMenuToolStripMenuItem1.Text = "CCMenu";
            // 
            // cCSpriteToolStripMenuItem
            // 
            this.cCSpriteToolStripMenuItem.Name = "cCSpriteToolStripMenuItem";
            this.cCSpriteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cCSpriteToolStripMenuItem.Text = "删除节点";
            this.cCSpriteToolStripMenuItem.Click += new System.EventHandler(this.OnDeleteClick);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.OnRenameClick);
            // 
            // mNewBtn
            // 
            this.mNewBtn.Location = new System.Drawing.Point(228, 35);
            this.mNewBtn.Name = "mNewBtn";
            this.mNewBtn.Size = new System.Drawing.Size(75, 23);
            this.mNewBtn.TabIndex = 1;
            this.mNewBtn.Text = "新建";
            this.mNewBtn.UseVisualStyleBackColor = true;
            this.mNewBtn.Click += new System.EventHandler(this.OnNewBtnClick);
            // 
            // mSaveBtn
            // 
            this.mSaveBtn.Location = new System.Drawing.Point(430, 36);
            this.mSaveBtn.Name = "mSaveBtn";
            this.mSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.mSaveBtn.TabIndex = 2;
            this.mSaveBtn.Text = "保存";
            this.mSaveBtn.UseVisualStyleBackColor = true;
            this.mSaveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
            // 
            // mOpenBtn
            // 
            this.mOpenBtn.Location = new System.Drawing.Point(330, 36);
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
            this.mFreshBtn.Location = new System.Drawing.Point(534, 35);
            this.mFreshBtn.Name = "mFreshBtn";
            this.mFreshBtn.Size = new System.Drawing.Size(75, 23);
            this.mFreshBtn.TabIndex = 6;
            this.mFreshBtn.Text = "刷新";
            this.mFreshBtn.UseVisualStyleBackColor = true;
            this.mFreshBtn.Click += new System.EventHandler(this.OnFreshClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(630, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "导出头文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onExportHppClick);
            // 
            // mPropertyWidget
            // 
            this.mPropertyWidget.Location = new System.Drawing.Point(253, 133);
            this.mPropertyWidget.Name = "mPropertyWidget";
            this.mPropertyWidget.Size = new System.Drawing.Size(470, 800);
            this.mPropertyWidget.TabIndex = 3;
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(605, 413);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(44, 38);
            this.upbtn.TabIndex = 8;
            this.upbtn.Text = "button2";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.onFunctionBtnClick);
            // 
            // downbtn
            // 
            this.downbtn.Location = new System.Drawing.Point(605, 472);
            this.downbtn.Name = "downbtn";
            this.downbtn.Size = new System.Drawing.Size(44, 34);
            this.downbtn.TabIndex = 9;
            this.downbtn.Text = "button3";
            this.downbtn.UseVisualStyleBackColor = true;
            this.downbtn.Click += new System.EventHandler(this.onFunctionBtnClick);
            // 
            // leftbtn
            // 
            this.leftbtn.Location = new System.Drawing.Point(553, 472);
            this.leftbtn.Name = "leftbtn";
            this.leftbtn.Size = new System.Drawing.Size(46, 33);
            this.leftbtn.TabIndex = 10;
            this.leftbtn.Text = "button4";
            this.leftbtn.UseVisualStyleBackColor = true;
            this.leftbtn.Click += new System.EventHandler(this.onFunctionBtnClick);
            // 
            // rightbtn
            // 
            this.rightbtn.Location = new System.Drawing.Point(656, 472);
            this.rightbtn.Name = "rightbtn";
            this.rightbtn.Size = new System.Drawing.Size(49, 33);
            this.rightbtn.TabIndex = 11;
            this.rightbtn.Text = "button5";
            this.rightbtn.UseVisualStyleBackColor = true;
            this.rightbtn.Click += new System.EventHandler(this.onFunctionBtnClick);
            // 
            // UiDesignWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rightbtn);
            this.Controls.Add(this.leftbtn);
            this.Controls.Add(this.downbtn);
            this.Controls.Add(this.upbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mSavePathLabel);
            this.Controls.Add(this.mFreshBtn);
            this.Controls.Add(this.mPropertyWidget);
            this.Controls.Add(this.mOpenBtn);
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
        private System.Windows.Forms.ToolStripMenuItem cCScale9SpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCLabelTTFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCLabelTTFEXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCNodeToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCMenuItemSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCMenuItemSpriteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cCMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCMenuToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Button downbtn;
        private System.Windows.Forms.Button leftbtn;
        private System.Windows.Forms.Button rightbtn;
    }
}
