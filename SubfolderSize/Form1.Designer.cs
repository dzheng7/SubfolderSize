namespace SubfolderSize
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.browseButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.clearButton = new System.Windows.Forms.Button();
            this.totalSizeBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runThisPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(168, 2);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(48, 21);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 365);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(379, 28);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.browseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(68, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 24);
            this.panel3.TabIndex = 4;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(190, 4);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(50, 21);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(109, 15);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.clearButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.startButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.newButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.totalSizeBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 34);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(385, 32);
            this.tableLayoutPanel2.TabIndex = 3;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(220, 2);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(48, 21);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // totalSizeBox
            // 
            this.totalSizeBox.BackColor = System.Drawing.SystemColors.Menu;
            this.totalSizeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalSizeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalSizeBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.totalSizeBox.Location = new System.Drawing.Point(2, 2);
            this.totalSizeBox.Margin = new System.Windows.Forms.Padding(2);
            this.totalSizeBox.Name = "totalSizeBox";
            this.totalSizeBox.Size = new System.Drawing.Size(110, 13);
            this.totalSizeBox.TabIndex = 4;
            this.totalSizeBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(116, 2);
            this.newButton.Margin = new System.Windows.Forms.Padding(2);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(48, 21);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Size,
            this.File});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(383, 291);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
            // 
            // Size
            // 
            this.Size.Text = "Size";
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 300;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyPathToolStripMenuItem,
            this.runThisPathToolStripMenuItem,
            this.openPathToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // copyPathToolStripMenuItem
            // 
            this.copyPathToolStripMenuItem.Name = "copyPathToolStripMenuItem";
            this.copyPathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyPathToolStripMenuItem.Text = "Copy Path";
            this.copyPathToolStripMenuItem.Click += new System.EventHandler(this.copyPathToolStripMenuItem_Click);
            // 
            // runThisPathToolStripMenuItem
            // 
            this.runThisPathToolStripMenuItem.Name = "runThisPathToolStripMenuItem";
            this.runThisPathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.runThisPathToolStripMenuItem.Text = "Run with Path";
            this.runThisPathToolStripMenuItem.Click += new System.EventHandler(this.runThisPathToolStripMenuItem_Click);
            // 
            // openPathToolStripMenuItem
            // 
            this.openPathToolStripMenuItem.Name = "openPathToolStripMenuItem";
            this.openPathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openPathToolStripMenuItem.Text = "Open";
            this.openPathToolStripMenuItem.Click += new System.EventHandler(this.openPathToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(273, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 24);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 365);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(405, 404);
            this.Name = "Form1";
            this.Text = "SubfolderSize";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox totalSizeBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backWorker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runThisPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPathToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

