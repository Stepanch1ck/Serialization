namespace Serialization
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainsplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainpictureBox = new System.Windows.Forms.PictureBox();
            this.MaintreeView = new System.Windows.Forms.TreeView();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.LoadTable = new System.Windows.Forms.Button();
            this.ShowTable = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).BeginInit();
            this.MainsplitContainer.Panel1.SuspendLayout();
            this.MainsplitContainer.Panel2.SuspendLayout();
            this.MainsplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // MainsplitContainer
            // 
            this.MainsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainsplitContainer.Name = "MainsplitContainer";
            // 
            // MainsplitContainer.Panel1
            // 
            this.MainsplitContainer.Panel1.Controls.Add(this.MaintreeView);
            this.MainsplitContainer.Panel1.Controls.Add(this.MainpictureBox);
            // 
            // MainsplitContainer.Panel2
            // 
            this.MainsplitContainer.Panel2.Controls.Add(this.Exit);
            this.MainsplitContainer.Panel2.Controls.Add(this.ShowTable);
            this.MainsplitContainer.Panel2.Controls.Add(this.LoadTable);
            this.MainsplitContainer.Panel2.Controls.Add(this.dataGridViewInfo);
            this.MainsplitContainer.Size = new System.Drawing.Size(800, 450);
            this.MainsplitContainer.SplitterDistance = 247;
            this.MainsplitContainer.TabIndex = 0;
            // 
            // MainpictureBox
            // 
            this.MainpictureBox.Image = ((System.Drawing.Image)(resources.GetObject("MainpictureBox.Image")));
            this.MainpictureBox.Location = new System.Drawing.Point(3, 0);
            this.MainpictureBox.Name = "MainpictureBox";
            this.MainpictureBox.Size = new System.Drawing.Size(224, 215);
            this.MainpictureBox.TabIndex = 0;
            this.MainpictureBox.TabStop = false;
            // 
            // MaintreeView
            // 
            this.MaintreeView.Location = new System.Drawing.Point(13, 222);
            this.MaintreeView.Name = "MaintreeView";
            this.MaintreeView.Size = new System.Drawing.Size(214, 149);
            this.MaintreeView.TabIndex = 1;
            this.MaintreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MaintreeView_AfterSelect);
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Location = new System.Drawing.Point(34, 145);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.Size = new System.Drawing.Size(486, 164);
            this.dataGridViewInfo.TabIndex = 0;
            // 
            // LoadTable
            // 
            this.LoadTable.Location = new System.Drawing.Point(34, 59);
            this.LoadTable.Name = "LoadTable";
            this.LoadTable.Size = new System.Drawing.Size(143, 52);
            this.LoadTable.TabIndex = 1;
            this.LoadTable.Text = "Загрузить";
            this.LoadTable.UseVisualStyleBackColor = true;
            this.LoadTable.Click += new System.EventHandler(this.LoadTable_Click);
            // 
            // ShowTable
            // 
            this.ShowTable.Enabled = false;
            this.ShowTable.Location = new System.Drawing.Point(203, 59);
            this.ShowTable.Name = "ShowTable";
            this.ShowTable.Size = new System.Drawing.Size(143, 52);
            this.ShowTable.TabIndex = 2;
            this.ShowTable.Text = "Показать";
            this.ShowTable.UseVisualStyleBackColor = true;
            this.ShowTable.Click += new System.EventHandler(this.ShowTable_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(377, 59);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(143, 52);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Закрыть";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainsplitContainer);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.MainsplitContainer.Panel1.ResumeLayout(false);
            this.MainsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).EndInit();
            this.MainsplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainsplitContainer;
        private System.Windows.Forms.PictureBox MainpictureBox;
        private System.Windows.Forms.TreeView MaintreeView;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button ShowTable;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        internal System.Windows.Forms.Button LoadTable;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

