﻿namespace UiEditor
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
            this.mNodesTree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // mNodesTree
            // 
            this.mNodesTree.Location = new System.Drawing.Point(3, 3);
            this.mNodesTree.Name = "mNodesTree";
            this.mNodesTree.Size = new System.Drawing.Size(185, 960);
            this.mNodesTree.TabIndex = 0;
            this.mNodesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "新建";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "打开";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // mPropertyGrid
            // 
            this.mPropertyGrid.Location = new System.Drawing.Point(253, 147);
            this.mPropertyGrid.Name = "mPropertyGrid";
            this.mPropertyGrid.Size = new System.Drawing.Size(330, 366);
            this.mPropertyGrid.TabIndex = 3;
            // 
            // UiDesignWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mPropertyGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mNodesTree);
            this.Name = "UiDesignWidget";
            this.Size = new System.Drawing.Size(723, 960);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView mNodesTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PropertyGrid mPropertyGrid;
    }
}
